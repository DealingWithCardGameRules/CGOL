using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.FluxxConcepts.Queries;
using System;
using System.Linq;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Handler
{
    public class MostKeepersHandler : IQueryHandler<MostKeepers, bool>
    {
        private readonly CardCounter cardCounter;

        public MostKeepersHandler(CardCounter cardCounter)
        {
            this.cardCounter = cardCounter ?? throw new ArgumentNullException(nameof(cardCounter));
        }

        public bool Handle(MostKeepers query)
        {
            var counts = cardCounter.Count("zone", "keepers");
            var playersKeeperZone = cardCounter.PlayersCollection("zone", "keepers");
            return counts.Where(x => x.Value == counts.Values.Max()).Any(c => c.Key.Equals(playersKeeperZone));
        }
    }
}
