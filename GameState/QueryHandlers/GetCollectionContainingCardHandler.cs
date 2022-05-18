using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.GameState.QueryHandlers
{
    public class GetCollectionContainingCardHandler : IQueryHandler<GetCollectionContainingCard, string?>
    {
        private readonly Game game;

        internal GetCollectionContainingCardHandler(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public string? Handle(GetCollectionContainingCard query)
        {
            return game.WhoHas(query.CardId);
        }
    }
}
