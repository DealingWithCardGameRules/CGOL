using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class ResolvePermanents : ICommand
    {
        public Guid ProcessId => new Guid("724B630A-2CD3-4452-B606-EB0795F3DC58");

        public Guid Instance { get; }
        public string? Zone { get; }

        [Concept(Description = "Resolve when active effects for a given card zone.")]
        public ResolvePermanents(string zone = null)
        {
            Instance = Guid.NewGuid();
            Zone = zone;
        }
    }
}
