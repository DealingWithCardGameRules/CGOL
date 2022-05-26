using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.CommonConcepts.Commands
{
    public class Win : ICommand
    {
        public Guid ProcessId => new Guid("A7FF39DA-E60D-4D78-A39C-8FBC2B5F2AD7");

        public Guid Instance { get; }
        public int? PlayerIndex { get; }

        [Concept(Description = "Declare the game won. Specify winning player index otherwise the current player is declared winner.")]
        public Win(int playerIndex = 0)
        {
            Instance = Guid.NewGuid();
            if (playerIndex > 0)
                PlayerIndex = playerIndex;
        }
    }
}
