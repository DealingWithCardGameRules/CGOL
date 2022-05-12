using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class CreateZone : ICommand
    {
        public Guid ProcessId => new Guid("CE030968-21BF-46E4-B9BA-96B545DB0847");

        public Guid Instance { get; }
        public string Name { get; }
        public string? Tags { get; }
        public int? PlayerIndex { get; }

        public CreateZone(string name, int playerIndex = -1, string tags = null)
        {
            Instance = Guid.NewGuid();
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Tags = tags;
            if (playerIndex > -1)
                PlayerIndex = playerIndex;
        }
    }
}
