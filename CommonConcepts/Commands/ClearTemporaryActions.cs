using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class ClearTemporaryActions : ICommand
    {
        public Guid ProcessId => new Guid("3A5B50A6-F942-4568-B435-DDF332DD90DD");

        public Guid Instance { get; }

        public ClearTemporaryActions()
        {
            Instance = Guid.NewGuid();
        }
    }
}
