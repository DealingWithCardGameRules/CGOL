using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
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
