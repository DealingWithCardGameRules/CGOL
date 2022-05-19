using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Events
{
    public class HandDeclared : IEvent
    {
        public int Version => 1;
        public DateTime EventTime { get; }
        public Guid ProcessId { get; }
        public string Name { get; }

        [Concept(Description = "The hand was declared.")]
        public HandDeclared(DateTime eventTime, Guid processId, string name)
        {
            EventTime = eventTime;
            ProcessId = processId;
            Name = name;
        }
    }
}
