using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.GameState.EventObservers
{
    public class CurrentPlayerSelectedObserver : IEventObserver<CurrentPlayerSelected>
    {
        private readonly Game game;

        internal CurrentPlayerSelectedObserver(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public async Task Invoke(CurrentPlayerSelected @event)
        {
            game.SetCurrentPlayer(@event.PlayerIndex);
        }
    }
}
