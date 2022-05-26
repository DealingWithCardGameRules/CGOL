using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.GameState.QueryHandlers
{
    public class GetNumberOfPlayersHandler : IQueryHandler<GetNumberOfPlayers, int>
    {
        private readonly Game game;

        internal GetNumberOfPlayersHandler(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public int Handle(GetNumberOfPlayers query)
        {
            return game.CountPlayers();
        }
    }
}
