using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.CommonConcepts.Events
{
    public class PlayerDeclared : IEvent
    {
        public int Version => 1;

        public DateTime EventTime { get; }

        public Guid ProcessId { get; }
        public IPlayer Player { get; }

        [Concept(Description = "The player was declared.")]
        public PlayerDeclared(DateTime eventTime, Guid processId, IPlayer player)
        {
            EventTime = eventTime;
            ProcessId = processId;
            Player = player;
        }

        public override string ToString()
        {
            return $"Player {Player.Name} entered the game.";
        }
    }
}
