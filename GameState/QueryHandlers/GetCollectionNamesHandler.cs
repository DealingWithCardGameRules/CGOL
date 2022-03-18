using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
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
            if (query.WithTags == null)
            {
                foreach (var item in game.CollectionNames())
                {
                    yield return item;
                }
            }
            else
            {
                foreach (var item in game.CollectionNames(query.WithTags))
                {
                    yield return item;
                }
            }
        }
    }
}
