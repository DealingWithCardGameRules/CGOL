using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.CommonConcepts.Events
{
    public class CardDealt : IEvent
    {
        public int Version => 1;
        public DateTime EventTime { get; }
        public Guid ProcessId { get; }
        public string Source { get; }
        public string Destination { get; }

        [Concept(Description = "A card was dealt from a source collection to a distination collection.")]
        public CardDealt(DateTime eventTime, Guid processId, string source, string destination)
        {
            EventTime = eventTime;
            ProcessId = processId;
            Source = source;
            Destination = destination;
        }

        public override string ToString()
        {
            return $"Card dealt from \"{Source}\" to \"{Destination}\"";
        }
    }
}
