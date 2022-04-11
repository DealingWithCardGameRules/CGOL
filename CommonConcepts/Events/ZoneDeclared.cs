using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Events
{
    public class ZoneDeclared : IEvent
    {
        public int Version => 1;

        public DateTime EventTime { get; }

        public Guid ProcessId { get; }
        public string Zone { get; }

        public ZoneDeclared(DateTime eventTime, Guid processId, string zone)
        {
            EventTime = eventTime;
            ProcessId = processId;
            Zone = zone;
        }
    }
}
