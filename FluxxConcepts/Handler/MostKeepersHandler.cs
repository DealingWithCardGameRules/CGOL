using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.FluxxConcepts.Queries;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Handler
{
    public class KeepersComparerHandler : IQueryHandler<MostKeepers, bool>
    {
        private readonly IQueryDispatcher dispatcher;
        private readonly string[] keeperZoneTags = new[] { "zone", "keepers" };

        public KeepersComparerHandler(IQueryDispatcher dispatcher)
        {
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        private string playersKeeperZone()
        {
            var player = dispatcher.Dispatch(new CurrentPlayer());
            if (player == null)
                throw new Exception("No current player. Remember to set up players");

            var playersKeeperZone = dispatcher.Dispatch(new GetCollectionNames { WithTags = keeperZoneTags, OwnedBy = player.Index });
            if (playersKeeperZone == null)
                throw new Exception("Current player has no keeper zone. Remember to create keepers zones, assign them to players and tag them with keepers.");
            
            return playersKeeperZone.First();
        }

        public Dictionary<string, int> CountKeepers()
        {
            var zones = dispatcher.Dispatch(new GetCollectionNames { WithTags = keeperZoneTags });

            Dictionary<string, int> counts = new Dictionary<string, int>();
            foreach (var zone in zones)
                counts[zone] = dispatcher.Dispatch(new CardCount(zone));
            return counts;
        }

        public bool Handle(MostKeepers query)
        {
            var counts = CountKeepers();
            var most = counts.Where(x => x.Value == counts.Values.Max()).Any(c => c.Key.Equals(playersKeeperZone()));
            return most;
        }
    }
}
