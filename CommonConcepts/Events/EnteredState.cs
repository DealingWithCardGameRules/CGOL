using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.CommonConcepts.Events
{
    public class EnteredState : IEvent
    {
        public int Version => 1;
        public DateTime EventTime { get; }
        public Guid ProcessId { get; }
        public string State { get; }

        [Concept(Description = "The game entered the state.")]
        public EnteredState(DateTime eventTime, Guid processId, string state)
        {
            EventTime = eventTime;
            ProcessId = processId;
            State = state;
        }

        public override string ToString()
        {
            return $"Entered state \"{State}\".";
        }
    }
}
