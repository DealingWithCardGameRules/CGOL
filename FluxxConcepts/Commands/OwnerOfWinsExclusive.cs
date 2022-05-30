using dk.itu.game.msc.cgol.CommonConcepts;
using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Commands
{
    public class OwnerOfWinsExclusive : ICommand
    {
        public Guid ProcessId => new Guid("B75CAC58-ADEE-412E-A685-4C5B0E98B7F7");

        public Guid Instance { get; }

        public IEnumerable<string> Keepers { get; }

        [Concept(Description = "Search all players keepers zone exclusively for the comma separated keepers specified. If one is found, the player immediately wins.")]
        public OwnerOfWinsExclusive(string keepers)
        {
            Instance = Guid.NewGuid();
            Keepers = keepers.CommaSeperateTrimmed();
        }
    }
}
