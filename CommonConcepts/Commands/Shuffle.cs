using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class Shuffle : ICommand
    {
        public Guid ProcessId => new Guid("9EEC3B13-A080-4F07-B6B8-B21DDBCCF9B2");

        public Guid Instance { get; }
        public string Collection { get; }

        public Shuffle(string collection)
        {
            Instance = Guid.NewGuid();
            Collection = collection ?? throw new ArgumentNullException(nameof(collection));
        }
    }
}
