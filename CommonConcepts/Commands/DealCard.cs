using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class DealCard : ICommand
    {
        public Guid ProcessId => new Guid("AAFE9EC9-EFA8-40DA-A37B-F3A856CFC5B0");
        [PlayCollection] public string Source { get; }
        public string? Destination { get; }
        public int Cards { get; }
        public Guid Instance { get; }

        [Concept(Description = "Deal cards from one collection to an other collection. If the to parameter is not set, the destination is set to the current players hand.")]
        public DealCard(string from, int cards = 1, string to = null)
        {
            Instance = Guid.NewGuid();
            Source = from;
            Cards = cards;
            Destination = to;
        }
    }
}
