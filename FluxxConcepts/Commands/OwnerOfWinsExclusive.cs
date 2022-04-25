using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts;
using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Commands
{
    public class OwnerOfWinsExclusive : ICommand
    {
        public Guid ProcessId => new Guid("A3AC5528-2F6F-4A20-8859-0A6E3A3C3303");

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
