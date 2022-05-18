using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.GameState.EventObservers
{
    public class EnteredStateObserver : IEventObserver<EnteredState>
    {
        private readonly Game game;

        internal EnteredStateObserver(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public void Invoke(EnteredState @event)
        {
            game.CurrentState = @event.State;
        }
    }
}
