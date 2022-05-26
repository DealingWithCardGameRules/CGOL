using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.CommonConcepts.Commands
{
    public class RemoveCollection : ICommand
    {
        public Guid ProcessId => new Guid("14949946-8F78-413D-B455-29336BEB9EE1");

        public Guid Instance { get; }
        public string Collection { get; }

        [Concept(Description = "Remove collection.")]
        public RemoveCollection(string collection)
        {
            Instance = Guid.NewGuid();
            Collection = collection ?? throw new ArgumentNullException(nameof(collection));
        }
    }
}
