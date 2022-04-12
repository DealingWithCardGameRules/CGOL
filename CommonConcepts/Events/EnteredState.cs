using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Events
{
    public class EnteredState : IEvent
    {
        public int Version => 1;
        public DateTime EventTime { get; }
        public Guid ProcessId { get; }
        public string State { get; }

        public EnteredState(DateTime eventTime, Guid processId, string state)
        {
            EventTime = eventTime;
            ProcessId = processId;
            State = state;
        }
    }
}
