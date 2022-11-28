using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.CommonConcepts.Handlers
{
    public class SimplyDeclareCollection : ICommandHandler<CreateDeck>
    {
        private readonly ITimeProvider timeProvider;

        public SimplyDeclareCollection(ITimeProvider timeProvider)
        {
            this.timeProvider = timeProvider;
        }

        public async Task Handle(CreateDeck command, IEventDispatcher eventDispatcher)
        {
            var @event = new CardCollectionDeclared(timeProvider.Now, command.ProcessId, command.Name);
            await eventDispatcher.Dispatch(@event);
        }
    }
}
