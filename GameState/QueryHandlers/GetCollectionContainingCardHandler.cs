using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.GameState.QueryHandlers
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
