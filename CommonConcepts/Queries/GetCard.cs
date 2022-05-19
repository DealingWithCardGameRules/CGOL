using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
{
    public class GetCard : IQuery<ICard?>
    {
        public string Collection { get; }
        public Guid CardId { get; }

        [Concept(Description = "Try to get a specific card from a specific collection.")]
        public GetCard(string collection, Guid cardId)
        {
            Collection = collection;
            CardId = cardId;
        }
    }
}
