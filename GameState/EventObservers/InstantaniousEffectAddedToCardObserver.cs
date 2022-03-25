﻿using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;

namespace dk.itu.game.msc.cgdl.GameState.EventObservers
{
    public class InstantaniousEffectAddedToCardObserver : IEventObserver<InstantaniousEffectAddedToCard>
    {
        private readonly Library library;

        public InstantaniousEffectAddedToCardObserver(Library library)
        {
            this.library = library ?? throw new System.ArgumentNullException(nameof(library));
        }

        public void Invoke(InstantaniousEffectAddedToCard @event)
        {
            library.AddInstantaneous(@event.UniqueCardName, @event.Command);
        }
    }
}