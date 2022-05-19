using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Events
{
    public class PlayerWon : IEvent
    {
        public int Version => 1;

        public DateTime EventTime { get; }

        public Guid ProcessId { get; }

        public int? PlayerIndex { get; }

        [Concept(Description = "The player was declared the winner.")]
        public PlayerWon(DateTime eventTime, Guid processId, int? playerIndex = null)
        {
            EventTime = eventTime;
            ProcessId = processId;
            PlayerIndex = playerIndex;
        }
    }
}
