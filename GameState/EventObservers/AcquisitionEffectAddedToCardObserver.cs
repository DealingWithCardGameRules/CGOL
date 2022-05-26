using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.GameState.EventObservers
{
    public class AcquisitionEffectAddedToCardObserver : IEventObserver<AcquisitionEffectAddedToCard>
    {
        private readonly Library library;

        internal AcquisitionEffectAddedToCardObserver(Library library)
        {
            this.library = library ?? throw new ArgumentNullException(nameof(library));
        }

        public void Invoke(AcquisitionEffectAddedToCard @event)
        {
            library.AddAcquisition(@event.UniqueCardName, @event.Command);
        }
    }
}
