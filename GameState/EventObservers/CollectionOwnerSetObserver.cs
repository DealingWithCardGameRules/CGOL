using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.GameState.EventObservers
{
    public class CollectionOwnerSetObserver : IEventObserver<CollectionOwnerSet>
    {
        private readonly Game game;

        public CollectionOwnerSetObserver(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public void Invoke(CollectionOwnerSet @event)
        {
            game.SetCollectionOwner(@event.Collection, @event.PlayerIndex);
        }
    }
}
