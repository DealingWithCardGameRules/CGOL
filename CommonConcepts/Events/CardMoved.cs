using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Events
{
    public class CardMoved : IEvent
    {
        public int Version => 1;
        public DateTime EventTime { get; }
        public Guid ProcessId { get; }
        public Guid SourceId { get; }
        public Guid DestinationId { get; }
        public Guid CardId { get; }

        public CardMoved(DateTime eventTime, Guid processId, Guid sourceId, Guid destinationId, Guid cardId)
        {
            EventTime = eventTime;
            ProcessId = processId;
            SourceId = sourceId;
            DestinationId = destinationId;
            CardId = cardId;
        }
    }
}
