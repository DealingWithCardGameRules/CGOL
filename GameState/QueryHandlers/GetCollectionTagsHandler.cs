using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgol.GameState.QueryHandlers
{
    public class GetCollectionTagsHandler : IQueryHandler<GetCollectionTags, IEnumerable<string>>
    {
        private readonly Game game;

        internal GetCollectionTagsHandler(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public IEnumerable<string> Handle(GetCollectionTags query)
        {
            return game.GetTags(query.Collection);
        }
    }
}
