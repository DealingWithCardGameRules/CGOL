using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts;
using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Commands
{
    public class OwnerOfWinsExclusive : ICommand
    {
        public Guid ProcessId => new Guid("B75CAC58-ADEE-412E-A685-4C5B0E98B7F7");

        public Guid Instance { get; }

        public IEnumerable<string> Keepers { get; }

        [Concept(Description = "Search all players keepers zone exclusively for the comma seperated keepers specified. If one is found, the player emidiately wins.")]
        public OwnerOfWinsExclusive(string keepers)
        {
            Instance = Guid.NewGuid();
            Keepers = keepers.CommaSeperateTrimmed();
        }
    }
}
