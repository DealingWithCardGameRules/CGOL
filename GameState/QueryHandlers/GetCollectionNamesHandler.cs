using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.GameState.QueryHandlers
{
    public class GetCollectionNamesHandler : IQueryHandler<GetCollectionNames, Func<IAsyncEnumerable<string>>>
    {
        private readonly Game game;

        internal GetCollectionNamesHandler(Game game)
        {
            this.game = game ?? throw new ArgumentNullException(nameof(game));
        }

        public async Task<Func<IAsyncEnumerable<string>>> Handle(GetCollectionNames query)
        {
            async IAsyncEnumerable<string> Handler()
            {
                foreach (var collection in game.CollectionNames(query.OwnedBy, query.WithTags))
                    yield return collection;
            }
            return () => Handler();
        }
    }
}
