using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
{
    public class CardCount : IQuery<int>
    {
        public Guid CollectionId { get; }

        public CardCount(Guid collectionId)
        {
            CollectionId = collectionId;
        }
    }
}
