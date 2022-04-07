using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Events
{
    public class DrawLimitSet : IEvent
    {
        public int Version => 1;

        public DateTime EventTime { get; set; }
        public Guid ProcessID { get; }
        public int DrawLimit { get; }
        public Guid ProcessId { get; set; }

        public DrawLimitSet(DateTime eventTime, Guid processID, int drawLimit)
        {
            EventTime = eventTime;
            ProcessID = processID;
            DrawLimit = drawLimit;
        }
    }
}
