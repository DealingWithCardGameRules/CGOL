using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.CommonConcepts.Handlers
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

        public async Task Handle(Start command, IEventDispatcher eventDispatcher)
        {
            await dispatcher.Dispatch(new ClearTemporaryActions());
            await eventDispatcher.Dispatch(new TurnStarted(timeProvider.Now, command.ProcessId));
            await dispatcher.Dispatch(new ResolvePermanents());
        }
    }
}
