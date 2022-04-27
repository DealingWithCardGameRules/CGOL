﻿using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.FluxxConcepts.Queries;
using System;
using System.Linq;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Handler
{
    public class MostKeepersHandler : IQueryHandler<MostKeepers, bool>
    {
        private readonly KeeperCounter keeperCounter;

        public MostKeepersHandler(KeeperCounter keeperCounter)
        {
            this.keeperCounter = keeperCounter ?? throw new ArgumentNullException(nameof(keeperCounter));
        }

        public bool Handle(MostKeepers query)
        {
            var counts = keeperCounter.CountKeepers();
            var most = counts.Where(x => x.Value == counts.Values.Max()).Any(c => c.Key.Equals(keeperCounter.PlayersKeeperZone()));
            return most;
        }
    }
}
