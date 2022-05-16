using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.Distribution;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.GameState.QueryHandlers
{
    public class GetCollectionNamesHandler : IQueryHandler<GetCollectionNames, IEnumerable<string>>
    {
        private readonly Game game;

        public GetCollectionNamesHandler(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public IEnumerable<string> Handle(GetCollectionNames query)
        {
            return game.CollectionNames(query.OwnedBy, query.WithTags);
        }
    }
}
