using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
{
    public class GetCard : IQuery<ICard?>
    {
        public Guid SourceId { get; }
        public Guid CardId { get; }

        public GetCard(Guid sourceId, Guid cardId)
        {
            SourceId = sourceId;
            CardId = cardId;
        }
    }
}
