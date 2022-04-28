using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;

namespace dk.itu.game.msc.cgdl.GameState.QueryHandlers
{
    public class GetRandomCardHandler : IQueryHandler<GetRandomCard, ICard?>
    {
        private readonly Game game;

        public GetRandomCardHandler(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public ICard? Handle(GetRandomCard query)
        {
            return game.GetRandomCard(query.Collection);
        }
    }
}
