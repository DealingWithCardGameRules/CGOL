using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;

namespace dk.itu.game.msc.cgdl.GameState.EventObservers
{
    public class CardAddedObserver : IEventObserver<CardAdded>
    {
        private readonly Game game;

        public CardAddedObserver(Game game)
        {
            this.game = game;
        }

        public void Invoke(CardAdded @event)
        {
            game.AddCard(@event.Destination, @event.Card);
        }
    }
}
