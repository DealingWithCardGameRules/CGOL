﻿using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.CommonConcepts.Queries
{
    public class HasCards : IQuery<bool>
    {
        public string? Collection { get; }

        [Concept(Description = "Check if collection has cards. If no collection is set, the current player hand is assumed.")]
        public HasCards(string collection = null)
        {
            Collection = collection;
        }
    }
}
