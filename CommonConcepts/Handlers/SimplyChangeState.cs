using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.CommonConcepts.Handlers
{
    public class SimplyChangeState : ICommandHandler<ChangeState>
    {
        private readonly ITimeProvider timeProvider;
        private readonly IDispatcher dispatcher;

        public SimplyChangeState(ITimeProvider timeProvider, IDispatcher dispatcher)
        {
            this.timeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public async Task Handle(ChangeState command, IEventDispatcher eventDispatcher)
        {
            if (await dispatcher.Dispatch(new InState(command.NewState)))
                return; // We're allready in the destinated state.

            var state = await dispatcher.Dispatch(new CurrentState());
            if (!string.IsNullOrEmpty(state))
            {
                // Event to trigger end of state events
                await eventDispatcher.Dispatch(new StateTransitionDeclared(timeProvider.Now, command.ProcessId, state));
            }

            await dispatcher.Dispatch(new ClearTemporaryActions());
            await eventDispatcher.Dispatch(new EnteredState(timeProvider.Now, command.ProcessId, command.NewState));
            await dispatcher.Dispatch(new ResolvePermanents());
        }
    }
}
