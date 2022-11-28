using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.GameState.QueryHandlers
{
    public class InStateHandler : IQueryHandler<InState, bool>
    {
        private readonly Game game;

        internal InStateHandler(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public async Task<bool> Handle(InState query)
        {
            return query.State.Equals(game.CurrentState, System.StringComparison.OrdinalIgnoreCase);
        }
    }
}
