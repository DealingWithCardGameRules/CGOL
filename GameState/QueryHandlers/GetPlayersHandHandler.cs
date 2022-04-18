using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;

namespace dk.itu.game.msc.cgdl.GameState.QueryHandlers
{
    public class GetPlayersHandHandler : IQueryHandler<GetPlayersHand, string?>
    {
        private readonly Game game;

        public GetPlayersHandHandler(Game game)
        {
            this.game = game;
        }

        public string? Handle(GetPlayersHand query)
        {
            return game.GetPlayerHand(query.PlayerIndex);
        }
    }
}
