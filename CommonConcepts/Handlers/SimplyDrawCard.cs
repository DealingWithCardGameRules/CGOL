using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.CommonConcepts.Handlers
{
    public class SimplyDrawCard : ICommandHandler<DrawCard>
    {
        private readonly ITimeProvider timeProvider;
        private readonly IDispatcher dispatcher;

        public SimplyDrawCard(ITimeProvider timeProvider, IDispatcher dispatcher)
        {
            this.timeProvider = timeProvider ?? throw new ArgumentNullException(nameof(timeProvider));
            this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        }

        public void Handle(DrawCard command, IEventDispatcher eventDispatcher)
        {
            var destination = command.Destination ?? CurrentPlayersHand();
            if (destination == null)
                throw new ArgumentNullException($"No destination found, please specify one by filling out the \"to\" parameter or make sure the current player has a hand.");

            if (!dispatcher.Dispatch(new HasCards(command.Source)))
            {
                var from = dispatcher.Dispatch(new GetReshuffleFromFor(command.Source));
                if (from == null)
                {
                    eventDispatcher.Dispatch(new CollectionBust(timeProvider.Now, command.ProcessId, command.Source));
                    throw new Exception($"No cards in collection {command.Source} and no reshuffle rule set.");
                }

                dispatcher.Dispatch(new ShuffleInto(from, command.Source));

                if (dispatcher.Dispatch(new HasCards(command.Source)))
                {
                    eventDispatcher.Dispatch(new CollectionBust(timeProvider.Now, command.ProcessId, command.Source));
                    throw new Exception($"No cards in collection {command.Source}");
                }
            }

            var @event = new CardDrawn(timeProvider.Now, command.ProcessId, command.Source, destination);
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
