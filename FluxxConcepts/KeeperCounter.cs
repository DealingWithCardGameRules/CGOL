using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.Distribution;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgdl.FluxxConcepts
{
    public class CardCounter
    {
        private readonly IQueryDispatcher dispatcher;

        public CardCounter(IQueryDispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        public string PlayersCollection(params string[] tags)
        {
            var player = dispatcher.Dispatch(new CurrentPlayer());
            if (player == null)
                throw new Exception("No current player. Remember to set up players");

            var playerCollection = dispatcher.Dispatch(new GetCollectionNames { WithTags = tags, OwnedBy = player.Index });
            if (playerCollection == null)
                throw new Exception("Current player has no keeper zone. Remember to create keepers zones, assign them to players and tag them with keepers.");

            return playerCollection.First();
        }

        public Dictionary<string, int> Count(params string[] tags)
        {
            var collections = dispatcher.Dispatch(new GetCollectionNames { WithTags = tags });

            Dictionary<string, int> counts = new Dictionary<string, int>();
            foreach (var collection in collections)
                counts[collection] = dispatcher.Dispatch(new CardCount(collection));
            return counts;
        }
    }
}
