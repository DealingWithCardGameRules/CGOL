using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Events
{
    public class CardOwnerSet : IEvent
    {
        public int Version => 1;
        public DateTime EventTime { get; }
        public Guid ProcessId { get; }
        public int PlayerIndex { get; }
        public Guid CardId { get; }

        public CardOwnerSet(DateTime eventTime, Guid processId, Guid cardInstance, int playerIndex)
        {
            EventTime = eventTime;
            ProcessId = processId;
            CardId = cardInstance;
            PlayerIndex = playerIndex;
        }
    }
}
