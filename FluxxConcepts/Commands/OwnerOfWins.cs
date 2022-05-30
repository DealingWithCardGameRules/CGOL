using dk.itu.game.msc.cgol.CommonConcepts;
using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Commands
{
    public class OwnerOfWins : ICommand
    {
        public Guid ProcessId => new Guid("A3AC5528-2F6F-4A20-8859-0A6E3A3C3303");

        public Guid Instance { get; }

        public IEnumerable<string> Keepers { get; }

        [Concept(Description = "Search all players keepers zone for the comma separated keepers specified. If one is found, the player immediately wins.")]
        public OwnerOfWins(string keepers)
        {
            Instance = Guid.NewGuid();
            Keepers = keepers.CommaSeperateTrimmed();
        }
    }
}
