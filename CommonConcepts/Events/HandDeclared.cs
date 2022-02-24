using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Events
{
    public class HandDeclared : IEvent
    {
        public int Version => 1;
        public DateTime EventTime { get; }
        public Guid ProcessId { get; }
        public Guid HandId { get; }

        public HandDeclared(DateTime eventTime, Guid processId, Guid handId)
        {
            EventTime = eventTime;
            ProcessId = processId;
            HandId = handId;
        }
    }
}
