using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
{
    public class SimplyDealCard : ICommandHandler<DealCard>
    {
        private readonly ITimeProvider timeProvider;
        private readonly IDispatcher dispatcher;

        public SimplyDealCard(ITimeProvider timeProvider, IDispatcher dispatcher)
        {
            this.timeProvider = timeProvider ?? throw new ArgumentNullException(nameof(timeProvider));
            this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        }

        public void Handle(DealCard command, IEventDispatcher eventDispatcher)
        {
            var destination = command.Destination ?? CurrentPlayersHand();
            if (dispatcher == null)
                throw new ArgumentNullException($"No destination found, please specify one by filling out the \"to\" parameter or make sure the current player has a hand.");

            var @event = new CardDealt(timeProvider.Now, command.ProcessId, command.Source, destination);
            eventDispatcher.Dispatch(@event);
        }

        private string? CurrentPlayersHand()
        {
            var player = dispatcher.Dispatch(new CurrentPlayer());
            if (player == null)
                throw new ArgumentException("No destination specified, please fill out the the \"to\" parameter or specify players with individual hands");

            return dispatcher.Dispatch(new GetPlayersHand(player.Index));
        }
    }
}
