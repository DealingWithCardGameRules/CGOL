using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.CommonConcepts.Commands
{
    public class PlayRandom : ICommand
    {
        public Guid ProcessId => new Guid("01AD13AB-1B5E-4616-A92E-3C87E12F6E8E");

        public Guid Instance { get; }
        public string? Collection { get; }

        [Concept(Description = "Play a random card from the collection. If collection is not specified, the players hand is assumed.")]
        public PlayRandom(string collection = null)
        {
            Instance = Guid.NewGuid();
            Collection = collection;
        }
    }
}
