﻿using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
{
    public class GetReshuffleFromFor : IQuery<string?>
    {
        public string Destination { get; }

        public GetReshuffleFromFor(string destination)
        {
            Destination = destination;
        }
    }
}
