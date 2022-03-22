using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts
{
    internal class SimpleLabraryCard : ICard
    {
        public Guid Instance { get; }

        public string Template { get; }

        public SimpleLabraryCard(ICardTemplate template)
        {
            Instance = Guid.NewGuid();
            Template = template.Template;
        }
    }
}
