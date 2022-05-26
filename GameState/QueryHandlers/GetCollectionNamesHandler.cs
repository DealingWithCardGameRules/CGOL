using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgol.GameState.QueryHandlers
{
    public class GetCollectionNamesHandler : IQueryHandler<GetCollectionNames, IEnumerable<string>>
    {
        private readonly Game game;

        internal GetCollectionNamesHandler(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public IEnumerable<string> Handle(GetCollectionNames query)
        {
            return game.CollectionNames(query.OwnedBy, query.WithTags);
        }
    }
}
