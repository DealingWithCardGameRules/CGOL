using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Events
{
    public class CardRevealed : IEvent
    {
        public int Version => 1;
        public DateTime EventTime { get; }
        public Guid ProcessId { get; }
        public Guid PlacementId { get; }
        public ICard Card { get; }

        public CardRevealed(DateTime eventTime, Guid processId, Guid placementId, ICard card)
        {
            EventTime = eventTime;
            ProcessId = processId;
            PlacementId = placementId;
            Card = card;
        }
    }
}
