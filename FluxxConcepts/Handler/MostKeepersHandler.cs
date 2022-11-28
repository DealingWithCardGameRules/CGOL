using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.FluxxConcepts.Queries;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Handler
{
    public class MostKeepersHandler : IQueryHandler<MostKeepers, bool>
    {
        private readonly CardCounter cardCounter;

        public MostKeepersHandler(CardCounter cardCounter)
        {
            this.cardCounter = cardCounter ?? throw new ArgumentNullException(nameof(cardCounter));
        }

        public async Task<bool> Handle(MostKeepers query)
        {
            var counts = await cardCounter.Count("zone", "keepers");
            var playersKeeperZone = await cardCounter.PlayersCollection("zone", "keepers");
            return counts.Where(x => x.Value == counts.Values.Max()).Any(c => c.Key.Equals(playersKeeperZone));
        }
    }
}
