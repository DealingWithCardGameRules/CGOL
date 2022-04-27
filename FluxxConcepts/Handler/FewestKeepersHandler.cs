using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.FluxxConcepts.Queries;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Handler
{
    public class FewestKeepersHandler : IQueryHandler<FewestKeepers, bool>
    {
        private readonly KeeperCounter keeperCounter;

        public FewestKeepersHandler(KeeperCounter keeperCounter)
        {
            this.keeperCounter = keeperCounter ?? throw new ArgumentNullException(nameof(keeperCounter));
        }

        public bool Handle(FewestKeepers query)
        {
            var counts = keeperCounter.CountKeepers();
            var most = counts.Where(x => x.Value == counts.Values.Min()).Any(c => c.Key.Equals(keeperCounter.PlayersKeeperZone()));
            return most;
        }
    }
}
