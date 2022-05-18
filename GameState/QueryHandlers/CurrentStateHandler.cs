﻿using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.GameState.QueryHandlers
{
    public class CurrentStateHandler : IQueryHandler<CurrentState, string?>
    {
        private readonly Game game;

        internal CurrentStateHandler(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public string? Handle(CurrentState query)
        {
            return game.CurrentState;
        }
    }
}
