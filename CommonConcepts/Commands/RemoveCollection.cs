using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class RemoveCollection : ICommand
    {
        public Guid ProcessId => new Guid("14949946-8F78-413D-B455-29336BEB9EE1");

        public Guid Instance { get; }
        public string Collection { get; }

        public RemoveCollection(string collection)
        {
            Instance = Guid.NewGuid();
            Collection = collection ?? throw new ArgumentNullException(nameof(collection));
        }
    }
}
