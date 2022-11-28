using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.GameState.EventObservers
{
    public class TemporaryActionsClearedObserver : IEventObserver<TemporaryActionsCleared>
    {
        private readonly CommandRepository temporaryCommandRepository;

        internal TemporaryActionsClearedObserver(CommandRepository temporaryCommandRepository)
        {
            this.temporaryCommandRepository = temporaryCommandRepository ?? throw new System.ArgumentNullException(nameof(temporaryCommandRepository));
        }

        public async Task Invoke(TemporaryActionsCleared @event)
        {
            temporaryCommandRepository.Clear();
        }
    }
}
