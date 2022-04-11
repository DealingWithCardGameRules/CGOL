using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;

namespace dk.itu.game.msc.cgdl.GameState.EventObservers
{
    public class CardCollectionDeclaredObserver : IEventObserver<CardCollectionDeclared>
    {
        private readonly Game game;

        public CardCollectionDeclaredObserver(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public void Invoke(CardCollectionDeclared @event)
        {
            game.AddCollection(new CardDeck(@event.Deck));
        }
    }
}
