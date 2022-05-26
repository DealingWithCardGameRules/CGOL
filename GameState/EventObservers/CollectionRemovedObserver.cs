using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.GameState.EventObservers
{
    public class CollectionRemovedObserver : IEventObserver<CollectionRemoved>
    {
        private readonly Game game;

        internal CollectionRemovedObserver(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public void Invoke(CollectionRemoved @event)
        {
            game.RemoveCollection(@event.Collection);
        }
    }
}
