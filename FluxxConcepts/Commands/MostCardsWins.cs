using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts;
using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Commands
{
    public class MostCardsWins : ICommand
    {
        public Guid ProcessId => new Guid("49DCD343-14DA-418A-85B3-474868A676B5");
        public Guid Instance { get; }
        public int MinCount { get; }
        public IEnumerable<string> Tags { get; }

        public MostCardsWins(string collectionTags, int minCount = 0)
        {
            Instance = Guid.NewGuid();
            MinCount = minCount;
            Tags = collectionTags.CommaSeperateTrimmed();
        }
    }
}
