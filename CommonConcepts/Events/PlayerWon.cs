using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.CommonConcepts.Events
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

        public override string ToString()
        {
            return $"Player {PlayerIndex??0} won!";
        }
    }
}
