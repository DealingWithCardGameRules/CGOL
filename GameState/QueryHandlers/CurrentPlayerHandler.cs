﻿using dk.itu.game.msc.cgol.CommonConcepts;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.GameState.QueryHandlers
{
    public class CurrentPlayerHandler : IQueryHandler<CurrentPlayer, IPlayer?>
    {
        private readonly Game game;

        internal CurrentPlayerHandler(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public async Task<IPlayer?> Handle(CurrentPlayer query)
        {
            return game.GetCurrentPlayer();
        }
    }
}