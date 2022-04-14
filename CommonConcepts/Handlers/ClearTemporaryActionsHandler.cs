using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
{
    public class ClearTemporaryActionsHandler : ICommandHandler<ClearTemporaryActions>
    {
        private readonly ITimeProvider timeProvider;

        public ClearTemporaryActionsHandler(ITimeProvider timeProvider)
        {
            this.timeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
        }

        public void Handle(ClearTemporaryActions command, IEventDispatcher eventDispatcher)
        {
            eventDispatcher.Dispatch(new TemporaryActionsCleared(timeProvider.Now, command.ProcessId));
        }
    }
}
