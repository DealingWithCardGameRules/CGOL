using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
{
    public class SimplyDeclareCollection : ICommandHandler<CreateDeck>
    {
        private readonly ITimeProvider timeProvider;

        public SimplyDeclareCollection(ITimeProvider timeProvider)
        {
            this.timeProvider = timeProvider;
        }

        public void Handle(CreateDeck command, IEventDispatcher eventDispatcher)
        {
            var @event = new CardCollectionDeclared(timeProvider.Now, command.ProcessId, command.Name);
            eventDispatcher.Dispatch(@event);
        }
    }
}
