using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.Distribution;
using dk.itu.game.msc.cgdl.FluxxConcepts.Commands;
using System;
using System.Linq;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Handler
{
    public class KeeperLimitHandler : ICommandHandler<KeeperLimit>
    {
        private readonly ITimeProvider timeProvider;
        private readonly IDispatcher dispatcher;

        public KeeperLimitHandler(ITimeProvider timeProvider, IDispatcher dispatcher)
        {
            this.timeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public void Handle(KeeperLimit command, IEventDispatcher eventDispatcher)
        {
            // All inactive players discard
            var players = dispatcher.Dispatch(new GetNumberOfPlayers());
            if (players == 0)
                return; // No players to discard from

            var currentPlayer = dispatcher.Dispatch(new CurrentPlayer())?.Index ?? -1;
            var tags = new[] { "zone", "keepers" };

            for (int i = 0; i < players; i++)
            {
                if ((i + 1) != currentPlayer)
                {
                    var hand = dispatcher.Dispatch(new GetCollectionNames { WithTags = tags, OwnedBy = i + 1 })?.FirstOrDefault();
                    if (hand == null)
                        throw new Exception($"Player {i + 1} has no keeper zone. Remember to assign ownership for keeper zones.");

                    dispatcher.Dispatch(new DiscardDownTo(hand, command.Limit, command.DiscardPile));
                }
            }
        }
    }
}
