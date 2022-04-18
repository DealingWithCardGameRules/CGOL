using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Events
{
    public class CardDealt : IEvent
    {
        public int Version => 1;
        public DateTime EventTime { get; }
        public Guid ProcessId { get; }
        public string Source { get; }
        public string Distination { get; }

        public CardDealt(DateTime eventTime, Guid processId, string source, string distination)
        {
            EventTime = eventTime;
            ProcessId = processId;
            Source = source;
            Distination = distination;
        }
    }
}
