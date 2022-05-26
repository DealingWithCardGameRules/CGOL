using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.GameState.EventObservers
{
    public class CardCollectionDeclaredObserver : IEventObserver<CardCollectionDeclared>
    {
        private readonly Game game;

        internal CardCollectionDeclaredObserver(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public void Invoke(CardCollectionDeclared @event)
        {
            game.AddCollection(new CardDeck(@event.Deck));
        }
    }
}
