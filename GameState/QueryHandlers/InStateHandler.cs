using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.GameState.QueryHandlers
{
    public class InStateHandler : IQueryHandler<InState, bool>
    {
        private readonly Game game;

        public InStateHandler(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public bool Handle(InState query)
        {
            return query.State.Equals(game.CurrentState, System.StringComparison.OrdinalIgnoreCase);
        }
    }
}
