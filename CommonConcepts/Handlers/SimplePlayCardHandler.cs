using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.CommonConcepts.Handlers
{
    public class SimplePlayCardHandler : ICommandHandler<PlayCard>
    {
        private readonly ITimeProvider timeProvider;
        private readonly IDispatcher dispatcher;

        public SimplePlayCardHandler(ITimeProvider timeProvider, IDispatcher dispatcher)
        {
            this.timeProvider = timeProvider ?? throw new ArgumentNullException(nameof(timeProvider));
            this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        }

        public async Task Handle(PlayCard command, IEventDispatcher eventDispatcher)
        {
            var source = await command.Source.Value(dispatcher);
            if (source == null)
                throw new ArgumentNullException($"No destination found, please specify one by filling out the \"from\" parameter or make sure the current player has a hand.");

            Guid selectedCard = await command.Card.ValueOrChoice(async (guids) => {
                var cards = ToCards(source, guids);
                return await SelectCard(cards.ToEnumerable());
                }, dispatcher);
        
            var card = await dispatcher.Dispatch(new GetCard(source, selectedCard)) ?? throw new Exception($"Card not found: {command.Card}");

            var revealEvent = new CardRevealed(timeProvider.Now, command.ProcessId, source, card);
            await eventDispatcher.Dispatch(revealEvent);

            var template = await dispatcher.Dispatch(new GetTemplate(card.Template));
            if (template == null)
                return; // No instantanious effects to resolve

            foreach (ICommand effect in template.Instantaneous)
            {
                effect.SetAffactSelfRef(card.Instance);
                await dispatcher.Dispatch(effect);
            }

            await eventDispatcher.Dispatch(new CardResolved(timeProvider.Now, command.ProcessId, card));

            if (command.Destination != null)
            {
                var moveEvent = new CardMoved(timeProvider.Now, command.ProcessId, source, command.Destination, card.Instance);
                await eventDispatcher.Dispatch(moveEvent);
            }
            
            command.Card.ClearChoice();
        }

        private async Task<Guid> SelectCard(IEnumerable<ICard> cards)
        {
            var player = await dispatcher.Dispatch(new CurrentPlayer());
            if (player == null)
                throw new ArgumentException("No card selected and no player to ask.");

            return await dispatcher.Dispatch(new PickACard(cards, player.Index, required: false)) ?? throw new Exception("No card selected!");
        }

        private async IAsyncEnumerable<ICard> ToCards(string source, IEnumerable<Guid> guids)
        {
            foreach (var guid in guids)
            {
                var card = await dispatcher.Dispatch(new GetCard(source, guid));
                if (card != null)
                    yield return card;
            }
        }
    }
}
