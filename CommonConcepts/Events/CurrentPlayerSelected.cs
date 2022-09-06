using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.CommonConcepts.Events
{
    public class CurrentPlayerSelected : IEvent
    {
        public int Version => 1;

        public DateTime EventTime { get; }

        public Guid ProcessId { get; }
        public int PlayerIndex { get; }

        [Concept(Description = "The current player was selected.")]
        public CurrentPlayerSelected(DateTime eventTime, Guid processId, int playerIndex)
        {
            EventTime = eventTime;
            ProcessId = processId;
            PlayerIndex = playerIndex;
        }

        public override string ToString()
        {
            return $"Current player is now player {PlayerIndex}";
        }
    }
}
