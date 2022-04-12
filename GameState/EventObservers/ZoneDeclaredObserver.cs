using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;

namespace dk.itu.game.msc.cgdl.GameState.EventObservers
{
    public class ZoneDeclaredObserver : IEventObserver<ZoneDeclared>
    {
        private readonly Game game;

        public ZoneDeclaredObserver(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public void Invoke(ZoneDeclared @event)
        {
            game.AddCollection(new CardZone(@event.Zone));
        }
    }
}
