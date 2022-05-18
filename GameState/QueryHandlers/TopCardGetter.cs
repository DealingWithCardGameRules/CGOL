﻿using dk.itu.game.msc.cgdl.CommonConcepts;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.GameState.QueryHandlers
{
    public class TopCardGetter : IQueryHandler<GetTopCard, ICard?>
    {
        private readonly Game game;

        internal TopCardGetter(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public ICard? Handle(GetTopCard query)
        {
            return game.GetCard(query.Collection);
        }
    }
}
