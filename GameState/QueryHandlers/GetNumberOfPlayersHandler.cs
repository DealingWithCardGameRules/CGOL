using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;

namespace dk.itu.game.msc.cgdl.GameState.QueryHandlers
{
    public class GetNumberOfPlayersHandler : IQueryHandler<GetNumberOfPlayers, int>
    {
        private readonly Game game;

        public GetNumberOfPlayersHandler(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public int Handle(GetNumberOfPlayers query)
        {
            return game.CountPlayers();
        }
    }
}
