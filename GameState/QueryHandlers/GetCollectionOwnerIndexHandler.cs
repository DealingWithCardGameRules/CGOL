using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;

namespace dk.itu.game.msc.cgdl.GameState.QueryHandlers
{
    public class GetCollectionOwnerIndexHandler : IQueryHandler<GetCollectionOwnerIndex, int?>
    {
        private readonly Game game;

        public GetCollectionOwnerIndexHandler(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public int? Handle(GetCollectionOwnerIndex query)
        {
            return game.GetCollectionOwner(query.Collection);
        }
    }
}
