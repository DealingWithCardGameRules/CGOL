using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts
{
    internal class SimpleLabraryCard : ICard
    {
        public string Name { get; }

        public Guid Instance { get; }

        public string Illustration { get; }

        public string Description { get; }

        public string? Template { get; }

        public SimpleLabraryCard(ICardTemplate template)
        {
            Name = template.Name;
            Instance = Guid.NewGuid();
            Illustration = template.Illustration;
            Description = template.Description;
            Template = template.Template;
        }
    }
}
