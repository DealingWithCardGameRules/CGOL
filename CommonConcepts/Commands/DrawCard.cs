using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class DrawCard : ICommand
    {
        public Guid ProcessId => new Guid("AAFE9EC9-EFA8-40DA-A37B-F3A856CFC5B0");
        public string Source { get; }
        public string Destination { get; }

        public DrawCard(string source, string destination)
        {
            Source = source;
            Destination = destination;
        }
    }
}
