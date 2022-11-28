using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.GameState.QueryHandlers
{
    public class GetCollectionTagsHandler : IQueryHandler<GetCollectionTags, Func<IAsyncEnumerable<string>>>
    {
        private readonly Game game;

        internal GetCollectionTagsHandler(Game game)
        {
            this.game = game ?? throw new ArgumentNullException(nameof(game));
        }

        public async Task<Func<IAsyncEnumerable<string>>> Handle(GetCollectionTags query)
        {
            async IAsyncEnumerable<string> Handler()
            {
                foreach (var tags in game.GetTags(query.Collection))
                    yield return tags;
            }
            return () => Handler();
        }
    }
}
