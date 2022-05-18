using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.GameState.EventObservers
{
    public class CollectionShuffledObserver : IEventObserver<CollectionShuffled>
    {
        private readonly Game game;

        internal CollectionShuffledObserver(Game game)
        {
            this.game = game;
        }

        public void Invoke(CollectionShuffled @event)
        {
            game.ShuffleCollection(@event.Collection, @event.Seed);
        }
    }
}
