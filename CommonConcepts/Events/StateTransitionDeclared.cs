using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Events
{
    public class StateTransitionDeclared : IEvent
    {
        public int Version => 1;

        public DateTime EventTime { get; }

        public Guid ProcessId { get; }
        public string State { get; }

        [Concept(Description = "This marks the end of the previous state.")]
        public StateTransitionDeclared(DateTime eventTime, Guid processId, string state)
        {
            EventTime = eventTime;
            ProcessId = processId;
            State = state;
        }
    }
}
