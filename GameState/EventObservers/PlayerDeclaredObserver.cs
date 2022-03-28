﻿using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;

namespace dk.itu.game.msc.cgdl.GameState.EventObservers
{
    public class PlayerDeclaredObserver : IEventObserver<PlayerDeclared>
    {
        private readonly Game game;

        public PlayerDeclaredObserver(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public void Invoke(PlayerDeclared @event)
        {
            game.SetPlayer(@event.Player);
        }
    }
}