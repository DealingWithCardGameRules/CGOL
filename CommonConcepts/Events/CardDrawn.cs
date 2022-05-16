using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Events
{
    public class CardDrawn : IEvent
    {
        public int Version => 1;
        public DateTime EventTime { get; }
        public Guid ProcessId { get; }
        public string Source { get; }
        public string Distination { get; }

        public CardDrawn(DateTime eventTime, Guid processId, string source, string distination)
        {
            EventTime = eventTime;
            ProcessId = processId;
            Source = source;
            Distination = distination;
        }
    }
}
