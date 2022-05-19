using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Events
{
    public class CardRevealed : IEvent
    {
        public int Version => 1;
        public DateTime EventTime { get; }
        public Guid ProcessId { get; }
        public string Placement { get; }
        public ICard Card { get; }

        [Concept(Description = "The card was revealed.")]
        public CardRevealed(DateTime eventTime, Guid processId, string placement, ICard card)
        {
            EventTime = eventTime;
            ProcessId = processId;
            Placement = placement;
            Card = card;
        }
    }
}
