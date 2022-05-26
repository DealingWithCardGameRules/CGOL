using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.GameState.EventObservers
{
    public class InstantaniousEffectAddedToCardObserver : IEventObserver<InstantaniousEffectAddedToCard>
    {
        private readonly Library library;

        internal InstantaniousEffectAddedToCardObserver(Library library)
        {
            this.library = library ?? throw new System.ArgumentNullException(nameof(library));
        }

        public void Invoke(InstantaniousEffectAddedToCard @event)
        {
            library.AddInstantaneous(@event.UniqueCardName, @event.Command);
        }
    }
}
