using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts
{
    public class CardDrawnEvent : IEvent
    {
        public int Version => 1;
        public DateTime EventTime { get; }
        public Guid ProcessId { get; }
        public Guid Source { get; }
        public Guid Distination { get; }

        public CardDrawnEvent(DateTime eventTime, Guid processId, Guid source, Guid distination)
        {
            EventTime = eventTime;
            this.ProcessId = processId;
            Source = source;
            Distination = distination;
        }
    }
}
