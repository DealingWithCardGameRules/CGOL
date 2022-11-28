using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.FluxxConcepts.Queries;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Handler
{
    public class OnlyHasKeepersHandler : IQueryHandler<OnlyHasKeepers, bool>
    {
        private readonly IQueryDispatcher dispatcher;

        public OnlyHasKeepersHandler(IQueryDispatcher dispatcher)
        {
            this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        }

        public async Task<bool> Handle(OnlyHasKeepers query)
        {
            var collection = query.Collection ?? await GetPlayersKeepersZone();
            if (collection == null)
                throw new Exception("No collection stated and no keepers zone for the current player. Please state collection manually or assign a keepers zone to the player.");
            var cards = (await dispatcher.Dispatch(new GetCards(collection)))();
            if (await cards.CountAsync() != query.Keepers.Count())
                return false; // Should have the exact same amount

            var TotalFound = 0;
            foreach (var keeper in query.Keepers)
            {
                var required = query.Keepers.Count(k => k.Equals(keeper));
                var found = await cards.CountAsync(c => c.Template.Equals(keeper));
                
                if (found < required)
                    return false;
                else
                    TotalFound++;
            }
            return TotalFound == query.Keepers.Count();
        }

        private async Task<string?> GetPlayersKeepersZone()
        {
            var player = await dispatcher.Dispatch(new CurrentPlayer());
            if (player == null)
                return null;

            var getCollectionNames = new GetCollectionNames()
            {
                OwnedBy = player.Index,
                WithTags = new[] { "zone", "keepers" }
            };
            var names = (await dispatcher.Dispatch(getCollectionNames))();
            return await names.SingleOrDefaultAsync();
        }
    }
}
