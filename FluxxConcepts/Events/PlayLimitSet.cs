using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Events
{
    public class PlayLimitSet : IEvent
    {
        public int Version => 1;

        public DateTime EventTime { get; }

        public Guid ProcessId { get; }

        public int Limit { get; }

        public PlayLimitSet(DateTime eventTime, Guid processId, int limit)
        {
            EventTime = eventTime;
            ProcessId = processId;
            Limit = limit;
        }
    }
}
