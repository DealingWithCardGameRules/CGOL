using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class ClearTemporaryActions : ICommand
    {
        public Guid ProcessId => new Guid("3A5B50A6-F942-4568-B435-DDF332DD90DD");

        public Guid Instance { get; }

        [Concept(Description = "Clears any actions brough forth by a when active effect.")]
        public ClearTemporaryActions()
        {
            Instance = Guid.NewGuid();
        }
    }
}
