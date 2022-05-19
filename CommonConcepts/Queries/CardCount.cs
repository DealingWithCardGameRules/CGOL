using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
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
