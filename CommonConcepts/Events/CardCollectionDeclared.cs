using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Events
{
    public class CardCollectionDeclared : IEvent
    {
        public int Version => 1;
        public DateTime EventTime { get; }
        public Guid ProcessId { get; }
        public string Stack { get; }

        public CardCollectionDeclared(DateTime eventTime, Guid processId, string stack)
        {
            EventTime = eventTime;
            ProcessId = processId;
            Stack = stack;
        }
    }
}
