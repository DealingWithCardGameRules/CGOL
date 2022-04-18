using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Commands
{
    public class DrawLimit : ICommand
    {
        public Guid ProcessId => new Guid("A90333E2-3804-4B3F-8105-BEC3E9DC2D93");

        public Guid Instance { get; }
        public int Limit { get; }

        public DrawLimit(int limit)
        {
            Instance = Guid.NewGuid();
            Limit = limit;
        }
    }
}
