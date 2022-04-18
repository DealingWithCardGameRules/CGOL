using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Commands
{
    public class PlayLimit : ICommand
    {
        public Guid ProcessId => new Guid("6A7BD1B5-BC54-46B5-8932-A099B3BE8C2D");

        public Guid Instance { get; }
        public int Limit { get; }

        public PlayLimit(int limit)
        {
            Instance = Guid.NewGuid();
            Limit = limit;
        }
    }
}
