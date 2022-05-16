using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.GameState.EventObservers
{
    public class TemporaryActionsClearedObserver : IEventObserver<TemporaryActionsCleared>
    {
        private readonly CommandRepository temporaryCommandRepository;

        public TemporaryActionsClearedObserver(CommandRepository temporaryCommandRepository)
        {
            this.temporaryCommandRepository = temporaryCommandRepository ?? throw new System.ArgumentNullException(nameof(temporaryCommandRepository));
        }

        public void Invoke(TemporaryActionsCleared @event)
        {
            temporaryCommandRepository.Clear();
        }
    }
}
