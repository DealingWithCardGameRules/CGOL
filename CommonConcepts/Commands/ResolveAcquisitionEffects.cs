using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Commands
{
    public class ResolveAcquisitionEffects : ICommand
    {
        public Guid ProcessId => new Guid("491AAB38-5184-4E79-AB60-F48A8ADD0CC4");

        public Guid Instance { get; }
        public ICard Card { get; }

        [Concept(Description = "Resolve the when drawn effect for a specific card. This can be utilized from a command.")]
        public ResolveAcquisitionEffects(ICard card)
        {
            Card = card;
        }
    }
}
