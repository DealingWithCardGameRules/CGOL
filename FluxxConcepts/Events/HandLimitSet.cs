using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Events
{
    public class HandLimitSet : IEvent
    {
        public int Version => 1;

        public DateTime EventTime { get; }

        public Guid ProcessId { get; }

        public int HandLimit { get; }

        public HandLimitSet(DateTime eventTime, Guid processId, int handLimit)
        {
            EventTime = eventTime;
            ProcessId = processId;
            HandLimit = handLimit;
        }
    }
}
