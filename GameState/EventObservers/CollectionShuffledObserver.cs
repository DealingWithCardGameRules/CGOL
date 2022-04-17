using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;

namespace dk.itu.game.msc.cgdl.GameState.EventObservers
{
    public class CollectionShuffledObserver : IEventObserver<CollectionShuffled>
    {
        private readonly Game game;

        public CollectionShuffledObserver(Game game)
        {
            this.game = game;
        }

        public void Invoke(CollectionShuffled @event)
        {
            game.ShuffleCollection(@event.Collection, @event.Seed);
        }
    }
}
