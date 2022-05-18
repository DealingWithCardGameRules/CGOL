using dk.itu.game.msc.cgdl.CommonConcepts;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.GameState.QueryHandlers
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
