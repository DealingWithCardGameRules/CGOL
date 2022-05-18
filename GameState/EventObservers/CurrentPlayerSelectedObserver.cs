using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.GameState.EventObservers
{
    public class CurrentPlayerSelectedObserver : IEventObserver<CurrentPlayerSelected>
    {
        private readonly Game game;

        internal CurrentPlayerSelectedObserver(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public void Invoke(CurrentPlayerSelected @event)
        {
            game.SetCurrentPlayer(@event.PlayerIndex);
        }
    }
}
