using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.FluxxConcepts.Commands;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Handler
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

        public async Task Handle(KeeperLimit command, IEventDispatcher eventDispatcher)
        {
            // All inactive players discard
            var players = await dispatcher.Dispatch(new GetNumberOfPlayers());
            if (players == 0)
                return; // No players to discard from

            var currentPlayer = (await dispatcher.Dispatch(new CurrentPlayer()))?.Index ?? -1;
            var tags = new[] { "zone", "keepers" };

            for (int i = 0; i < players; i++)
            {
                if ((i + 1) != currentPlayer)
                {
                    var hand = await (await dispatcher.Dispatch(new GetCollectionNames { WithTags = tags, OwnedBy = i + 1 }))().FirstOrDefaultAsync();
                    if (hand == null)
                        throw new Exception($"Player {i + 1} has no keeper zone. Remember to assign ownership for keeper zones.");

                    await dispatcher.Dispatch(new DiscardDownTo(hand, command.Limit, command.DiscardPile));
                }
            }
        }
    }
}
