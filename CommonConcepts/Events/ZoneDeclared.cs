using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.CommonConcepts.Events
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

        public override string ToString()
        {
            var owner = OwnerIndex != null ? $"Owned by player {OwnerIndex}" : "";
            return $"Card zone \"{Zone}\" declared. {owner}";
        }
    }
}
