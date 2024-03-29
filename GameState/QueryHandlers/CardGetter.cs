﻿using dk.itu.game.msc.cgol.CommonConcepts;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.GameState.QueryHandlers
{
    public class CardGetter : IQueryHandler<GetCard, ICard?>
    {
        private readonly Game game;

        internal CardGetter(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public async Task<ICard?> Handle(GetCard query)
        {
            return game.GetCard(query.Collection, query.CardId);
        }
    }
}
