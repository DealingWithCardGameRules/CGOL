using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.CommonConcepts.Events
{
    public class CardAdded : IEvent
    {
        public int Version => 1;
        public DateTime EventTime { get; }
        public Guid ProcessId { get; }
        public ICard Card { get; }
        public string Destination { get; }

        [Concept(Description = "Card was added to a collection")]
        public CardAdded(DateTime eventTime, Guid processId, ICard card, string destination)
        {
            EventTime = eventTime;
            ProcessId = processId;
            Card = card;
            Destination = destination;
        }
    }
}
