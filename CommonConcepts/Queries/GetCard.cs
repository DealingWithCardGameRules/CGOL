using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
{
    public class GetCard : IQuery<ICard?>
    {
        public string Collection { get; }
        public Guid CardId { get; }

        public GetCard(string collection, Guid cardId)
        {
            Collection = collection;
            CardId = cardId;
        }
    }
}
