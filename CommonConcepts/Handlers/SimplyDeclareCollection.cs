using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
{
    public class SimplyDeclareCollection : ICommandHandler<CreateCollection>
    {
        private readonly ITimeProvider timeProvider;

        public SimplyDeclareCollection(ITimeProvider timeProvider)
        {
            this.timeProvider = timeProvider;
        }

        public void Handle(CreateCollection command, IEventDispatcher eventDispatcher)
        {
            var @event = new CardCollectionDeclared(timeProvider.Now, command.ProcessId, command.Name);
            eventDispatcher.Dispatch(@event);
        }
    }
}
