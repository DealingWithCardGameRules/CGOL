using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.GameState.EventObservers
{
    public class EnteredStateObserver : IEventObserver<EnteredState>
    {
        private readonly Game game;

        internal EnteredStateObserver(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public async Task Invoke(EnteredState @event)
        {
            game.CurrentState = @event.State;
        }
    }
}
