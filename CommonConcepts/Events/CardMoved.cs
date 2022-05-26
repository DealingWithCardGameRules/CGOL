using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.CommonConcepts.Events
{
    public class CardMoved : IEvent
    {
        public int Version => 1;
        public DateTime EventTime { get; }
        public Guid ProcessId { get; }
        public string Source { get; }
        public string Destination { get; }
        public Guid CardId { get; }

        [Concept(Description = "The specified card moved from the source to the destination.")]
        public CardMoved(DateTime eventTime, Guid processId, string sourceId, string destinationId, Guid cardId)
        {
            EventTime = eventTime;
            ProcessId = processId;
            Source = sourceId;
            Destination = destinationId;
            CardId = cardId;
        }
    }
}
