using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.CommonConcepts
{
    internal class SimpleLabraryCard : TagHandler, ICard
    {
        public Guid Instance { get; }

        public string Template { get; }

        public SimpleLabraryCard(ICardTemplate template) : base(template.Tags)
        {
            Instance = Guid.NewGuid();
            Template = template.Template;
        }
    }
}
