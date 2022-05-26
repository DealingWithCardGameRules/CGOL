using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.CommonConcepts.Events
{
    public class CardOwnerSet : IEvent
    {
        public int Version => 1;
        public DateTime EventTime { get; }
        public Guid ProcessId { get; }
        public int PlayerIndex { get; }
        public Guid CardId { get; }

        [Concept(Description = "The owner of the card was set to the given player.")]
        public CardOwnerSet(DateTime eventTime, Guid processId, Guid cardInstance, int playerIndex)
        {
            EventTime = eventTime;
            ProcessId = processId;
            CardId = cardInstance;
            PlayerIndex = playerIndex;
        }
    }
}
