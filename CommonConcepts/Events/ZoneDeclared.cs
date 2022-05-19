using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Events
{
    public class ZoneDeclared : IEvent
    {
        public int Version => 1;

        public DateTime EventTime { get; }

        public Guid ProcessId { get; }
        public string Zone { get; }
        public int? OwnerIndex { get; }

        [Concept(Description = "The zone was declared.")]
        public ZoneDeclared(DateTime eventTime, Guid processId, string zone, int? ownerIndex)
        {
            EventTime = eventTime;
            ProcessId = processId;
            Zone = zone;
            OwnerIndex = ownerIndex;
        }
    }
}
