using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class DrawCard : ICommand
    {
        public Guid ProcessId => new Guid("AAFE9EC9-EFA8-40DA-A37B-F3A856CFC5B0");
        [PlayCollection] public string Source { get; }
        public string? Destination { get; }
        public Guid Instance { get; }

        [Concept(Description = "Draw a card from one collection and place it in an other collection. If the to parameter is not set, the destination is set to the current players hand.")]
        public DrawCard(string from, string to = null)
        {
            Instance = Guid.NewGuid();
            Source = from;
            Destination = to;
        }
    }
}
