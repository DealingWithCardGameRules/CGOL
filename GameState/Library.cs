﻿using dk.itu.game.msc.cgol.CommonConcepts;
using dk.itu.game.msc.cgol.Distribution;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgol.GameState
{
    internal class Library
    {
        private readonly Dictionary<string, ICardTemplate> library;

        public Library()
        {
            library = new Dictionary<string, ICardTemplate>();
        }

        public void AddCardTemplate(string template, ICardTemplate card)
        {
            library.Add(template, new SimpleTemplate(template)); // Instance problems
        }

        public void AddInstantaneous(string template, ICommand command)
        {
            library[template].AddInstantaneous(command);
        }

        internal void AddAcquisition(string template, ICommand command)
        {
            library[template].AddAcquisition(command);
        }

        internal void AddTags(string template, IEnumerable<string> tags)
        {
            foreach (var tag in tags)
                library[template].AddTag(tag);
        }

        public void AddPermanent(string template, ICommand command)
        {
            library[template].AddPermanent(command);
        }

        public ICardTemplate? GetCardTemplate(string template)
        {
            if (library.ContainsKey(template))
                return library[template];
            return null;
        }
    }
}
