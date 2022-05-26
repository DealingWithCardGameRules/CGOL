using dk.itu.game.msc.cgol.CommonConcepts;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.GameState.QueryHandlers
{
    public class GetRandomCardHandler : IQueryHandler<GetRandomCard, ICard?>
    {
        private readonly Game game;

        internal GetRandomCardHandler(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public ICard? Handle(GetRandomCard query)
        {
            return game.GetRandomCard(query.Collection);
        }
    }
}
