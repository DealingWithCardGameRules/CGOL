using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.GameState.QueryHandlers
{
    public class GetPlayersHandHandler : IQueryHandler<GetPlayersHand, string?>
    {
        private readonly Game game;

        internal GetPlayersHandHandler(Game game)
        {
            this.game = game;
        }

        public async Task<string?> Handle(GetPlayersHand query)
        {
            var player = query.PlayerIndex ?? game.GetCurrentPlayer()?.Index;
            if (!player.HasValue)
                return null;
            return game.GetPlayerHand(player.Value);
        }
    }
}
