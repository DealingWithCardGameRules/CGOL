using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.GameState.QueryHandlers
{
    public class CurrentStateHandler : IQueryHandler<CurrentState, string?>
    {
        private readonly Game game;

        internal CurrentStateHandler(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public string? Handle(CurrentState query)
        {
            return game.CurrentState;
        }
    }
}
