using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.CommonConcepts.Commands
{
    public class Shuffle : ICommand
    {
        public Guid ProcessId => new Guid("9EEC3B13-A080-4F07-B6B8-B21DDBCCF9B2");

        public Guid Instance { get; }
        public string Collection { get; }

        [Concept(Description = "Shuffle the cards of a collection.")]
        public Shuffle(string collection)
        {
            Instance = Guid.NewGuid();
            Collection = collection ?? throw new ArgumentNullException(nameof(collection));
        }
    }
}
