using System;

namespace dk.itu.game.msc.cgol.CommonConcepts
{
    internal class SimpleLibraryCard : TagHandler, ICard
    {
        public Guid Instance { get; set; }

        public string Template { get; }
        public int? OwnerIndex { get; set; }

        public SimpleLibraryCard(ICardTemplate template) : base(template.Tags)
        {
            Instance = Guid.NewGuid();
            Template = template.Template;
        }
    }
}
