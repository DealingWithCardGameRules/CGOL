using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class CommandBundle : ICommand
    {
        public Guid ProcessId => new Guid("38AF7C74-43E7-4252-BC2C-25C7B3290425");

        public Guid Instance { get; }
        [AffectSelf] public Guid? SelfRef { get; set; }
        public IEnumerable<ICommand> Commands { get; }

        public CommandBundle(ICommand[] commands)
        {
            Instance = Guid.NewGuid();
            Commands = commands;
        }
    }
}
