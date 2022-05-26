using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.CommonConcepts.Queries
{
    public class GetTopCard : IQuery<ICard?>
    {
        public string Collection { get; }

        [Concept(Description = "Try to get the top card of a specific collection.")]
        public GetTopCard(string collection)
        {
            Collection = collection;
        }
    }
}
