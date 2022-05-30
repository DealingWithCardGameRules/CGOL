using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Commands
{
    public class PlayLimit : ICommand
    {
        public Guid ProcessId => new Guid("6A7BD1B5-BC54-46B5-8932-A099B3BE8C2D");

        public Guid Instance { get; }
        public int Limit { get; }

        [Concept(Description = "Set the limit of cards a player can play during their turn.")]
        public PlayLimit(int limit)
        {
            Instance = Guid.NewGuid();
            Limit = limit;
        }
    }
}
