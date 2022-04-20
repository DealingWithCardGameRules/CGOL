using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Events
{
    public class RecycleRuleSet : IEvent
    {
        public int Version => 1;

        public DateTime EventTime { get; }

        public Guid ProcessId { get; }
        public string From { get; }
        public string To { get; }

        public RecycleRuleSet(DateTime eventTime, Guid processId, string from, string to)
        {
            EventTime = eventTime;
            ProcessId = processId;
            From = from;
            To = to;
        }
    }
}
