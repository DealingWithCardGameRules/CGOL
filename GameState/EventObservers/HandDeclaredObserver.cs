using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;

namespace dk.itu.game.msc.cgdl.GameState.EventObservers
{
    public class HandDeclaredObserver : IEventObserver<HandDeclared>
    {
        private readonly Game game;

        public HandDeclaredObserver(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public void Invoke(HandDeclared @event)
        {
            game.AddHand(new Hand(@event.HandId));
        }
    }
}
