using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;

namespace dk.itu.game.msc.cgdl.GameState.EventObservers
{
    public class CurrentPlayerSelectedObserver : IEventObserver<CurrentPlayerSelected>
    {
        private readonly Game game;

        public CurrentPlayerSelectedObserver(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public void Invoke(CurrentPlayerSelected @event)
        {
            game.SetCurrentPlayer(@event.PlayerIndex);
        }
    }
}
