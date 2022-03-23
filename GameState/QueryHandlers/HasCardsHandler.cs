using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;

namespace dk.itu.game.msc.cgdl.GameState.QueryHandlers
{
    public class HasCardsHandler : IQueryHandler<HasCards, bool>
    {
        private readonly Game game;

        public HasCardsHandler(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public bool Handle(HasCards query)
        {
            return game.CollectionSize(query.Collection) > 0;
        }
    }
}
