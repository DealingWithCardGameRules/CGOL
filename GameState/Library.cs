﻿using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.GameState
{
    public class Library
    {
        private readonly Dictionary<string, ICardTemplate> library;

        public Library()
        {
            library = new Dictionary<string, ICardTemplate>();
        }

        public void AddCardTemplate(string template, ICardTemplate card)
        {
            library.Add(template, card);
        }

        public void AddInstantaneous(string template, ICommand command)
        {
            library[template].AddInstantaneous(command);
        }

        public void AddPermanent(string template, ICommand command)
        {
            library[template].AddPermanent(command);
        }

        public ICardTemplate GetCardTemplate(string template)
        {
            return library[template];
        }
    }
}