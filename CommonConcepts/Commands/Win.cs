using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class Win : ICommand
    {
        public Guid ProcessId => new Guid("A7FF39DA-E60D-4D78-A39C-8FBC2B5F2AD7");

        public Guid Instance { get; }

        public Win()
        {
            Instance = Guid.NewGuid();
        }
    }
}
