﻿using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.GameState.EventObservers
{
    public class PlayerDeclaredObserver : IEventObserver<PlayerDeclared>
    {
        private readonly Game game;

        internal PlayerDeclaredObserver(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public void Invoke(PlayerDeclared @event)
        {
            game.SetPlayer(@event.Player);
        }
    }
}
