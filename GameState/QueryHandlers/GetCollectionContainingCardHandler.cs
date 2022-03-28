using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;

namespace dk.itu.game.msc.cgdl.GameState.QueryHandlers
{
    public class GetCollectionContainingCardHandler : IQueryHandler<GetCollectionContainingCard, string?>
    {
        private readonly Game game;

        public GetCollectionContainingCardHandler(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public string? Handle(GetCollectionContainingCard query)
        {
            return game.WhoHas(query.CardId);
        }
    }
}
