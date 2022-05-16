using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.GameState.EventObservers
{
    public class AcquisitionEffectAddedToCardObserver : IEventObserver<AcquisitionEffectAddedToCard>
    {
        private readonly Library library;

        public AcquisitionEffectAddedToCardObserver(Library library)
        {
            this.library = library ?? throw new ArgumentNullException(nameof(library));
        }

        public void Invoke(AcquisitionEffectAddedToCard @event)
        {
            library.AddAcquisition(@event.UniqueCardName, @event.Command);
        }
    }
}
