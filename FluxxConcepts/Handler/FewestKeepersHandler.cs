using dk.itu.game.msc.cgdl.Distribution;
using dk.itu.game.msc.cgdl.FluxxConcepts.Queries;
using System;
using System.Linq;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Handler
{
    public class FewestKeepersHandler : IQueryHandler<FewestKeepers, bool>
    {
        private readonly CardCounter cardCounter;

        public FewestKeepersHandler(CardCounter cardCounter)
        {
            this.cardCounter = cardCounter ?? throw new ArgumentNullException(nameof(cardCounter));
        }

        public bool Handle(FewestKeepers query)
        {
            var counts = cardCounter.Count("zone", "keepers");
            var playersKeeperZone = cardCounter.PlayersCollection("zone", "keepers");
            return counts.Where(x => x.Value == counts.Values.Min()).Any(c => c.Key.Equals(playersKeeperZone));
        }
    }
}
