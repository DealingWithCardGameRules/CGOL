﻿using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.GameState.QueryHandlers
{
    public class HasCollectionHandler : IQueryHandler<HasCollection, bool>
    {
        private readonly Game game;

        internal HasCollectionHandler(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public bool Handle(HasCollection query)
        {
            return game.HasCollection(query.Name);
        }
    }
}
