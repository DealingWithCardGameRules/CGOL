using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
{
    public class SimplyRevealAndMove : ICommandHandler<PlayCard>
    {
        private readonly ITimeProvider timeProvider;
        private readonly IQueryDispatcher dispatcher;
        private IPlayer cachedPlayer;

        public SimplyRevealAndMove(ITimeProvider timeProvider, IQueryDispatcher dispatcher)
        {
            this.timeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
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
            
            if (command.Destination != null)
            {
                var moveEvent = new CardMoved(timeProvider.Now, command.ProcessId, source, command.Destination, command.Card.Value);
                eventDispatcher.Dispatch(moveEvent);
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
