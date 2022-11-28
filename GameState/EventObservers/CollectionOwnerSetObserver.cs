using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.GameState.EventObservers
{
    public class CollectionOwnerSetObserver : IEventObserver<CollectionOwnerSet>
    {
        private readonly Game game;

        internal CollectionOwnerSetObserver(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public async Task Invoke(CollectionOwnerSet @event)
        {
            game.SetCollectionOwner(@event.Collection, @event.PlayerIndex);
        }
    }
}
