using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
{
    public class SimplyDeclareZone : ICommandHandler<CreateZone>
    {
        private readonly ITimeProvider timeProvider;
        private readonly IDispatcher dispatcher;

        public SimplyDeclareZone(ITimeProvider timeProvider, IDispatcher dispatcher)
        {
            this.timeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public void Handle(CreateZone command, IEventDispatcher eventDispatcher)
        {
            eventDispatcher.Dispatch(new ZoneDeclared(timeProvider.Now, command.ProcessId, command.Name));
            if (command.PlayerIndex.HasValue)
                dispatcher.Dispatch(new CollectionOwner(command.Name, command.PlayerIndex.Value));
        }
    }
}
