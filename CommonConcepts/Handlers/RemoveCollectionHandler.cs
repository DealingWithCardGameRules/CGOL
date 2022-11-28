using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.CommonConcepts.Handlers
{
    public class RemoveCollectionHandler : ICommandHandler<RemoveCollection>
    {
        private readonly ITimeProvider timeProvider;

        public RemoveCollectionHandler(ITimeProvider timeProvider)
        {
            this.timeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
        }

        public async Task Handle(RemoveCollection command, IEventDispatcher eventDispatcher)
        {
            await eventDispatcher.Dispatch(new CollectionRemoved(timeProvider.Now, command.ProcessId, command.Collection));
        }
    }
}
