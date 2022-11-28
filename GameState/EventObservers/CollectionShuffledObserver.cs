using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.GameState.EventObservers
{
    public class CollectionShuffledObserver : IEventObserver<CollectionShuffled>
    {
        private readonly Game game;

        internal CollectionShuffledObserver(Game game)
        {
            this.game = game;
        }

        public async Task Invoke(CollectionShuffled @event)
        {
            game.ShuffleCollection(@event.Collection, @event.Seed);
        }
    }
}
