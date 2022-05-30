using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Commands
{
    public class DrawLimit : ICommand
    {
        public Guid ProcessId => new Guid("A90333E2-3804-4B3F-8105-BEC3E9DC2D93");

        public Guid Instance { get; }
        public int Limit { get; }

        [Concept(Description = "Set the limit of cards a player can draw during their turn.")]
        public DrawLimit(int limit)
        {
            Instance = Guid.NewGuid();
            Limit = limit;
        }
    }
}
