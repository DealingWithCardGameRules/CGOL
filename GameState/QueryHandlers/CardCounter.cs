using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.GameState.QueryHandlers
{
    public class CardCounter : IQueryHandler<CardCount, int>
    {
        private readonly Game game;

        internal CardCounter(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public int Handle(CardCount query)
        {
            return game.CollectionSize(query.Collection);
        }
    }
}
