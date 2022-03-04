using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
{
    public class SimplyDeclareHand : ICommandHandler<CreateHand>
    {
        private readonly ITimeProvider timeProvider;

        public SimplyDeclareHand(ITimeProvider timeProvider)
        {
            this.timeProvider = timeProvider;
        }

        public void Handle(CreateHand command, IEventDispatcher eventDispatcher)
        {
            var @event = new HandDeclared(timeProvider.Now, command.ProcessId, command.Hand);
            eventDispatcher.Dispatch(@event);
        }
    }
}
