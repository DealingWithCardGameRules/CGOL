using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.CommonConcepts.Handlers
{
    public class DiscardCardsHandler : ICommandHandler<DiscardCards>
    {
        private readonly ITimeProvider timeProvider;
        private readonly IDispatcher dispatcher;

        public DiscardCardsHandler(ITimeProvider timeProvider, IDispatcher dispatcher)
        {
            this.timeProvider = timeProvider ?? throw new ArgumentNullException(nameof(timeProvider));
            this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        }

        public async Task Handle(DiscardCards command, IEventDispatcher eventDispatcher)
        {
            if (!await dispatcher.Dispatch(new HasCollection(command.Source)))
                throw new Exception($"The source collection \"{command.Source}\" was not found. Remember to declare the collection using {nameof(CreateDeck)}, {nameof(CreateZone)} or {nameof(CreateHand)}");

            if (!await dispatcher.Dispatch(new HasCollection(command.Destination)))
                throw new Exception($"The destination collection \"{command.Destination}\" was not found. Remember to declare the collection using {nameof(CreateDeck)}, {nameof(CreateZone)} or {nameof(CreateHand)}");

            var cards = await dispatcher.Dispatch(new GetCards(command.Source, command.Tags));
            
            await foreach (var card in cards())
                await eventDispatcher.Dispatch(new CardMoved(timeProvider.Now, command.ProcessId, command.Source, command.Destination, card.Instance));
        }
    }
}
