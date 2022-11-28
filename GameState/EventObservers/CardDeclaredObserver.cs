﻿using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.GameState.EventObservers
{
    public class CardDeclaredObserver : IEventObserver<CardDeclared>
    {
        private readonly Library library;

        internal CardDeclaredObserver(Library library)
        {
            this.library = library ?? throw new System.ArgumentNullException(nameof(library));
        }

        public async Task Invoke(CardDeclared @event)
        {
            library.AddCardTemplate(@event.Template, @event.Card);
        }
    }
}
