using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Events
{
    public class TurnStarted : IEvent
    {
        public int Version => 1;

        public DateTime EventTime { get; }

        public Guid ProcessId { get; }

        public TurnStarted(DateTime eventTime, Guid processId)
        {
            EventTime = eventTime;
            ProcessId = processId;
        }
    }
}
