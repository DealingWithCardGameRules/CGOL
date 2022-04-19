using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using System;
using dk.itu.game.msc.cgdl.CommonConcepts;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Handler
{
    public class PlayCardHandler : ICommandHandler<PlayCard>
    {
        private readonly ITimeProvider timeProvider;
        private readonly IDispatcher dispatcher;
        private IPlayer cachedPlayer;

        public PlayCardHandler(ITimeProvider timeProvider, IDispatcher dispatcher)
        {
            this.timeProvider = timeProvider ?? throw new ArgumentNullException(nameof(timeProvider));
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public void Handle(PlayCard command, IEventDispatcher eventDispatcher)
        {
            var source = command.Source ?? CurrentPlayersHand();
            if (source == null)
                throw new ArgumentNullException($"No destination found, please specify one by filling out the \"from\" parameter or make sure the current player has a hand.");

            var selectedCard = command.Card ?? dispatcher.Dispatch(new PickACard(source, cachedPlayer.Index));
            if (selectedCard == null)
                throw new Exception("No card selected!");

            var card = dispatcher.Dispatch(new GetCard(source, selectedCard.Value));

            if (card == null)
                throw new Exception($"Card not found: {command.Card}");

            var revealEvent = new CardRevealed(timeProvider.Now, command.ProcessId, source, card);
            eventDispatcher.Dispatch(revealEvent);

            var template = dispatcher.Dispatch(new GetTemplate(card.Template));
            if (template == null)
                return; // No instantanious effects to resolve

            foreach (ICommand effect in template.Instantaneous)
            {
                effect.SetAffactSelfRef(card.Instance);
                dispatcher.Dispatch(effect);
            }
        }

        private string? CurrentPlayersHand()
        {
            cachedPlayer = dispatcher.Dispatch(new CurrentPlayer());
            if (cachedPlayer == null)
                throw new ArgumentException("No source specified, please fill out the the \"source\" parameter or specify players with individual hands");

            return dispatcher.Dispatch(new GetPlayersHand(cachedPlayer.Index));
        }

    }
}
