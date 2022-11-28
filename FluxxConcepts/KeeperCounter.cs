using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.FluxxConcepts
{
    public class CardCounter
    {
        private readonly IQueryDispatcher dispatcher;

        public CardCounter(IQueryDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        public async Task<string> PlayersCollection(params string[] tags)
        {
            var player = await dispatcher.Dispatch(new CurrentPlayer());
            if (player == null)
                throw new Exception("No current player. Remember to set up players");

            var playerCollection = await dispatcher.Dispatch(new GetCollectionNames { WithTags = tags, OwnedBy = player.Index });
            if (playerCollection == null)
                throw new Exception("Current player has no keeper zone. Remember to create keepers zones, assign them to players and tag them with keepers.");

            return await playerCollection().FirstAsync();
        }

        public async Task<Dictionary<string, int>> Count(params string[] tags)
        {
            var collections = await dispatcher.Dispatch(new GetCollectionNames { WithTags = tags });

            Dictionary<string, int> counts = new Dictionary<string, int>();
            await foreach (var collection in collections())
                counts[collection] = await dispatcher.Dispatch(new CardCount(collection));
            return counts;
        }
    }
}
