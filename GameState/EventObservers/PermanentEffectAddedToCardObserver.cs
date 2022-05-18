using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.GameState.EventObservers
{
    public class PermanentEffectAddedToCardObserver : IEventObserver<PermanentEffectAddedToCard>
    {
        private readonly Library library;

        internal PermanentEffectAddedToCardObserver(Library library)
        {
            this.library = library ?? throw new System.ArgumentNullException(nameof(library));
        }

        public void Invoke(PermanentEffectAddedToCard @event)
        {
            library.AddPermanent(@event.UniqueCardName, @event.Command);
        }
    }
}
