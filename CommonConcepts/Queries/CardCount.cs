using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.CommonConcepts.Queries
{
    public class CardCount : IQuery<int>
    {
        public string Collection { get; }

        [Concept(Description = "Counts the amount of cards in the collection.")]
        public CardCount(string collection)
        {
            Collection = collection;
        }
    }
}
