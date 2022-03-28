using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;

namespace dk.itu.game.msc.cgdl.GameState.QueryHandlers
{
    public class CurrentPlayerHandler : IQueryHandler<CurrentPlayer, IPlayer?>
    {
        private readonly Game game;

        public CurrentPlayerHandler(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public IPlayer? Handle(CurrentPlayer query)
        {
            return game.GetCurrentPlayer();
        }
    }
}