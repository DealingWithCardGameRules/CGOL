using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class ClaimOwnership : ICommand
    {
        public Guid ProcessId => new Guid("D1792841-F3E1-4088-819C-54A9D2921126");

        public Guid Instance { get; }
        public string Collection { get; }

        [Concept(Description = "Set owner of each card in a collection to the same owner of the collection. If the collection is not specified, the current players hand is assumed.")]
        public ClaimOwnership(string collection = null)
        {
            Instance = Guid.NewGuid();
            Collection = collection;
        }
    }
}
