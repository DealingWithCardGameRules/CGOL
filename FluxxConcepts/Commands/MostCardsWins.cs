using dk.itu.game.msc.cgol.CommonConcepts;
using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Commands
{
    public class MostCardsWins : ICommand
    {
        public Guid ProcessId => new Guid("49DCD343-14DA-418A-85B3-474868A676B5");
        public Guid Instance { get; }
        public int MinCount { get; }
        public IEnumerable<string> Tags { get; }

        [Concept(Description = "Counts cards in collections that contain the tags. The owner of the collection with the most cards wins. If minCount is set, a player only wins if they have at least that many cards.")]
        public MostCardsWins(string collectionTags, int minCount = 0)
        {
            Instance = Guid.NewGuid();
            MinCount = minCount;
            Tags = collectionTags.CommaSeperateTrimmed();
        }
    }
}
