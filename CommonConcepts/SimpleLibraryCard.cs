using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts
{
    internal class SimpleLibraryCard : TagHandler, ICard
    {
        public Guid Instance { get; }

        public string Template { get; }
        public int? OwnerIndex { get; set; }

        public SimpleLibraryCard(ICardTemplate template) : base(template.Tags)
        {
            Instance = Guid.NewGuid();
            Template = template.Template;
        }
    }
}
