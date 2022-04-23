using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;

namespace dk.itu.game.msc.cgdl.GameState.EventObservers
{
    public class CollectionRemovedObserver : IEventObserver<CollectionRemoved>
    {
        private readonly Game game;

        public CollectionRemovedObserver(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public void Invoke(CollectionRemoved @event)
        {
            game.RemoveCollection(@event.Collection);
        }
    }
}
