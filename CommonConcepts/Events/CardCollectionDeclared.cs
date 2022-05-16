using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Events
{
    public class CardCollectionDeclared : IEvent
    {
        public int Version => 1;
        public DateTime EventTime { get; }
        public Guid ProcessId { get; }
        public string Deck { get; }

        public CardCollectionDeclared(DateTime eventTime, Guid processId, string deck)
        {
            EventTime = eventTime;
            ProcessId = processId;
            Deck = deck;
        }
    }
}
