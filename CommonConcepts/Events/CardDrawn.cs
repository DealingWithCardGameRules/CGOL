using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Events
{
    public class CardDrawn : IEvent
    {
        public int Version => 1;
        public DateTime EventTime { get; }
        public Guid ProcessId { get; }
        public Guid Source { get; }
        public Guid Distination { get; }
        public Guid Card { get; }

        public CardDrawn(DateTime eventTime, Guid processId, Guid source, Guid distination, Guid card)
        {
            EventTime = eventTime;
            ProcessId = processId;
            Source = source;
            Distination = distination;
            Card = card;
        }
    }
}
