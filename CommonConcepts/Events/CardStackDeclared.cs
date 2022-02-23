using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Events
{
    public class CardStackDeclared : IEvent
    {
        public int Version => 1;
        public DateTime EventTime { get; }
        public Guid ProcessId { get; }
        public Guid StackId { get; }

        public CardStackDeclared(DateTime eventTime, Guid processId, Guid stackId)
        {
            EventTime = eventTime;
            ProcessId = processId;
            StackId = stackId;
        }
    }
}
