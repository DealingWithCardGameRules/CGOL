using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
{
    public class SimplyDeclareHand : ICommandHandler<CreateHand>
    {
        private readonly ITimeProvider timeProvider;
        private readonly IDispatcher dispatcher;

        public SimplyDeclareHand(ITimeProvider timeProvider, IDispatcher dispatcher)
        {
            this.timeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public void Handle(CreateHand command, IEventDispatcher eventDispatcher)
        {
            eventDispatcher.Dispatch(new HandDeclared(timeProvider.Now, command.ProcessId, command.Hand));
            if (command.PlayerIndex.HasValue)
                dispatcher.Dispatch(new CollectionOwner(command.Hand, command.PlayerIndex.Value));
        }
    }
}
