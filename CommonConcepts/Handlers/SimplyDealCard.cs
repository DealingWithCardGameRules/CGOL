using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.Distribution;
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

            for (int i = 0; i < command.Cards; i++)
            {
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

                var @event = new CardDealt(timeProvider.Now, command.ProcessId, command.Source, destination);
                eventDispatcher.Dispatch(@event);
            }
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
