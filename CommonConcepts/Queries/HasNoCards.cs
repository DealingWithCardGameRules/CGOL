﻿using dk.itu.game.msc.cgdl.CommandCentral;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
{
    public class HasNoCards : IQuery<bool>
    {
        public string? Collection { get; }

        public HasNoCards(string collection = null)
        {
            Collection = collection;
        }
    }
}