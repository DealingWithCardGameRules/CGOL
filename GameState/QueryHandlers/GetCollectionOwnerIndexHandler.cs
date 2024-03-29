﻿using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.GameState.QueryHandlers
{
    public class GetCollectionOwnerIndexHandler : IQueryHandler<GetCollectionOwnerIndex, int?>
    {
        private readonly Game game;

        internal GetCollectionOwnerIndexHandler(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public async Task<int?> Handle(GetCollectionOwnerIndex query)
        {
            return game.GetCollectionOwner(query.Collection);
        }
    }
}
