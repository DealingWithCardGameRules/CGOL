using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class DrawCard : ICommand
    {
        public Guid ProcessId => new Guid("AAFE9EC9-EFA8-40DA-A37B-F3A856CFC5B0");
        [PlayFrom] public string Source { get; }
        public string Destination { get; }
        public Guid Instance { get; }
        public DrawCard(string from, string to)
        {
            Instance = Guid.NewGuid();
            Source = from;
            Destination = to;
        }
    }
}
