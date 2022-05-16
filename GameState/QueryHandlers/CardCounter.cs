using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.GameState.QueryHandlers
{
    public class CardCounter : IQueryHandler<CardCount, int>
    {
        private readonly Game game;

        public CardCounter(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public int Handle(CardCount query)
        {
            return game.CollectionSize(query.Collection);
        }
    }
}
