using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.GameState.QueryHandlers
{
    public class GetCollectionOwnerIndexHandler : IQueryHandler<GetCollectionOwnerIndex, int?>
    {
        private readonly Game game;

        internal GetCollectionOwnerIndexHandler(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public int? Handle(GetCollectionOwnerIndex query)
        {
            return game.GetCollectionOwner(query.Collection);
        }
    }
}
