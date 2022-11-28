using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.GameState.EventObservers
{
    public class PermanentEffectAddedToCardObserver : IEventObserver<PermanentEffectAddedToCard>
    {
        private readonly Library library;

        internal PermanentEffectAddedToCardObserver(Library library)
        {
            this.library = library ?? throw new System.ArgumentNullException(nameof(library));
        }

        public async Task Invoke(PermanentEffectAddedToCard @event)
        {
            library.AddPermanent(@event.UniqueCardName, @event.Command);
        }
    }
}
