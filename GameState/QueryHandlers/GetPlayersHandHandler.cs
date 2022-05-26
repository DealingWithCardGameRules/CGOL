using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.GameState.QueryHandlers
{
    public class GetPlayersHandHandler : IQueryHandler<GetPlayersHand, string?>
    {
        private readonly Game game;

        internal GetPlayersHandHandler(Game game)
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
