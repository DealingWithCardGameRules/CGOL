using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.CommonConcepts.Commands
{
    public class CollectionOwner : ICommand
    {
        public Guid ProcessId => new Guid("35939A28-D2C2-4098-B0B1-C1AB9FBA685A");

        public Guid Instance { get; set; }
        public int? PlayerIndex { get; }
        public string Collection { get; set; }

        [Concept(Description = "Set the owner of a card collection to a given player index.")]
        public CollectionOwner(string collection, int playerIndex = 0)
        {
            Instance = Guid.NewGuid();
            Collection = collection;
            if (playerIndex != 0)
                PlayerIndex = playerIndex;
        }
    }
}
