using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.CommonConcepts.Handlers
{
    public class ClearTemporaryActionsHandler : ICommandHandler<ClearTemporaryActions>
    {
        private readonly ITimeProvider timeProvider;

        public ClearTemporaryActionsHandler(ITimeProvider timeProvider)
        {
            this.timeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
        }

        public async Task Handle(ClearTemporaryActions command, IEventDispatcher eventDispatcher)
        {
            await eventDispatcher.Dispatch(new TemporaryActionsCleared(timeProvider.Now, command.ProcessId));
        }
    }
}
