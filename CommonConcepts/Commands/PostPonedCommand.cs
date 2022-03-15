using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class PostponedCommand : ICommand
    {
        public Guid ProcessId => new Guid("85A8EA4B-4945-4F41-B3CC-C4A127F00DC9");

        public ICommand Command { get; }

        public PostponedCommand(ICommand command)
        {
            Command = command;
        }
    }
}
