using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.GameState.QueryHandlers
{
    public class GetCollectionContainingCardHandler : IQueryHandler<GetCollectionContainingCard, string?>
    {
        private readonly Game game;

        internal GetCollectionContainingCardHandler(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public async Task<string?> Handle(GetCollectionContainingCard query)
        {
            return game.WhoHas(query.CardId);
        }
    }
}
