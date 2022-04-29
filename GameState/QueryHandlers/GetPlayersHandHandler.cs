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
            var player = query.PlayerIndex ?? game.GetCurrentPlayer()?.Index;
            if (!player.HasValue)
                return null;
            return game.GetPlayerHand(player.Value);
        }
    }
}
