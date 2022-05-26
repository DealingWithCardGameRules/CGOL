using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.CommonConcepts.Handlers
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
