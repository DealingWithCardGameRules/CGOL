using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Events
{
    public class TurnEnded : IEvent
    {
        public int Version => 1;

        public DateTime EventTime { get; }

        public Guid ProcessId { get; }

        public TurnEnded(DateTime eventTime, Guid processId)
        {
            EventTime = eventTime;
            ProcessId = processId;
        }
    }
}
