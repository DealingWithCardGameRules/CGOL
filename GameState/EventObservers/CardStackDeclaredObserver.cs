using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;

namespace dk.itu.game.msc.cgdl.GameState.EventObservers
{
    public class CardStackDeclaredObserver : IEventObserver<CardStackDeclared>
    {
        private readonly Game game;

        public CardStackDeclaredObserver(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public void Invoke(CardStackDeclared @event)
        {
            game.AddStack(new CardStack(@event.StackId));
        }
    }
}
