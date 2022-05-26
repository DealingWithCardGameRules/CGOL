using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.CommonConcepts.Events
{
    public class CardCollectionDeclared : IEvent
    {
        public int Version => 1;
        public DateTime EventTime { get; }
        public Guid ProcessId { get; }
        public string Deck { get; }
        [Concept(Description = "Card collection was declared.")]
        public CardCollectionDeclared(DateTime eventTime, Guid processId, string deck)
        {
            EventTime = eventTime;
            ProcessId = processId;
            Deck = deck;
        }
    }
}
