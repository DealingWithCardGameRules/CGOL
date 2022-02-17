using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class DrawCardCommand : ICommand
    {
        public Guid ProcessId => new Guid("AAFE9EC9-EFA8-40DA-A37B-F3A856CFC5B0");
        public Guid Source { get; }
        public Guid Destination { get; }

        public DrawCardCommand(Guid source, Guid destination)
        {
            Source = source;
            Destination = destination;
        }
    }
}
