using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.FluxxConcepts.Queries;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Handler
{
    public class FewestKeepersHandler : IQueryHandler<FewestKeepers, bool>
    {
        private readonly CardCounter cardCounter;

        public FewestKeepersHandler(CardCounter cardCounter)
        {
            this.cardCounter = cardCounter ?? throw new ArgumentNullException(nameof(cardCounter));
        }

        public async Task<bool> Handle(FewestKeepers query)
        {
            var counts = await cardCounter.Count("zone", "keepers");
            var playersKeeperZone = await cardCounter.PlayersCollection("zone", "keepers");
            return counts.Where(x => x.Value == counts.Values.Min()).Any(c => c.Key.Equals(playersKeeperZone));
        }
    }
}
