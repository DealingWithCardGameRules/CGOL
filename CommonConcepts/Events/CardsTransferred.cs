using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.CommonConcepts.Events
{
    public class CardsTransferred : IEvent
    {
        public int Version => 1;

        public DateTime EventTime { get; }

        public Guid ProcessId { get; }
        public string Source { get; }
        public string Destination { get; }

        [Concept(Description = "A card was transferred from the source to the destination.")]
        public CardsTransferred(DateTime eventTime, Guid processId, string source, string destination)
        {
            EventTime = eventTime;
            ProcessId = processId;
            Source = source;
            Destination = destination;
        }
    }
}
