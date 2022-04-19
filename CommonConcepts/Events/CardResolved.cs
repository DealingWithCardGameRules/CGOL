using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Events
{
    public class CardResolved : IEvent
    {
        public int Version => 1;

        public DateTime EventTime { get; }

        public Guid ProcessId { get; }
        public ICard Card { get; }

        public CardResolved(DateTime eventTime, Guid processId, ICard card)
        {
            EventTime = eventTime;
            ProcessId = processId;
            Card = card;
        }
    }
}
