using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
{
    public class SimplyDeclareStack : ICommandHandler<CreateStack>
    {
        private readonly ITimeProvider timeProvider;

        public SimplyDeclareStack(ITimeProvider timeProvider)
        {
            this.timeProvider = timeProvider;
        }

        public void Handle(CreateStack command, IEventDispatcher eventDispatcher)
        {
            var @event = new CardStackDeclared(timeProvider.Now, command.ProcessId, command.StackId);
            
            eventDispatcher.Dispatch(@event);
        }
    }
}
