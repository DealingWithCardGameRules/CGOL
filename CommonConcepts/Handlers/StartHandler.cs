using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
{
    public class StartHandler : ICommandHandler<Start>
    {
        private readonly ITimeProvider timeProvider;
        private readonly IDispatcher dispatcher;

        public StartHandler(ITimeProvider timeProvider, IDispatcher dispatcher)
        {
            this.timeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public void Handle(Start command, IEventDispatcher eventDispatcher)
        {
            dispatcher.Dispatch(new ClearTemporaryActions());
            eventDispatcher.Dispatch(new TurnStarted(timeProvider.Now, command.ProcessId));
            dispatcher.Dispatch(new ResolvePermanents());
        }
    }
}
