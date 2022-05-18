using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.GameState.EventObservers
{
    public class CardDeclaredObserver : IEventObserver<CardDeclared>
    {
        private readonly Library library;

        internal CardDeclaredObserver(Library library)
        {
            this.library = library ?? throw new System.ArgumentNullException(nameof(library));
        }

        public void Invoke(CardDeclared @event)
        {
            library.AddCardTemplate(@event.Template, @event.Card);
        }
    }
}
