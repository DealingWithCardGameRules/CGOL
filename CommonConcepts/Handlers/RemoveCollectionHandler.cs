using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
{
    public class RemoveCollectionHandler : ICommandHandler<RemoveCollection>
    {
        private readonly ITimeProvider timeProvider;

        public RemoveCollectionHandler(ITimeProvider timeProvider)
        {
            this.timeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
        }

        public void Handle(RemoveCollection command, IEventDispatcher eventDispatcher)
        {
            eventDispatcher.Dispatch(new CollectionRemoved(timeProvider.Now, command.ProcessId, command.Collection));
        }
    }
}
