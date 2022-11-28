using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.Distribution;

namespace CGOLConsole.Handlers
{
    public class GameWonObserver : IEventObserver<PlayerWon>
    {
        private readonly GameStats stats;

        internal GameWonObserver(GameStats stats)
        {
            this.stats = stats ?? throw new ArgumentNullException(nameof(stats));
        }

        public async Task Invoke(PlayerWon @event)
        {
            stats.playerWon = @event.PlayerIndex;
            stats.gameOver = true;
        }
    }
}
