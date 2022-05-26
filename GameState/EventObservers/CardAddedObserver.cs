using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.GameState.EventObservers
{
    public class CardAddedObserver : IEventObserver<CardAdded>
    {
        private readonly Game game;

        internal CardAddedObserver(Game game)
        {
            this.game = game;
        }

        public void Invoke(CardAdded @event)
        {
            game.AddCard(@event.Destination, @event.Card);
        }
    }
}
