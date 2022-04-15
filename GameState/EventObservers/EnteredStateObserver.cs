﻿using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;

namespace dk.itu.game.msc.cgdl.GameState.EventObservers
{
    public class EnteredStateObserver : IEventObserver<EnteredState>
    {
        private readonly Game game;

        public EnteredStateObserver(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public void Invoke(EnteredState @event)
        {
            game.CurrentState = @event.State;
        }
    }
}