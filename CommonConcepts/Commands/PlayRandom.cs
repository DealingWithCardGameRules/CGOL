using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class PlayRandom : ICommand
    {
        public Guid ProcessId => new Guid("01AD13AB-1B5E-4616-A92E-3C87E12F6E8E");

        public Guid Instance { get; }
        public string? Collection { get; }

        public PlayRandom(string collection = null)
        {
            Instance = Guid.NewGuid();
            Collection = collection;
        }
    }
}
