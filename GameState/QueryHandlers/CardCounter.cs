using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.GameState.QueryHandlers
{
    public class CardCounter : IQueryHandler<CardCount, int>
    {
        private readonly Game game;

        internal CardCounter(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public async Task<int> Handle(CardCount query)
        {
            return game.CollectionSize(query.Collection);
        }
    }
}
