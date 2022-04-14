using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
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

        public void Handle(ChangeState command, IEventDispatcher eventDispatcher)
        {
            if (dispatcher.Dispatch(new InState(command.NewState)))
                return; // We're allready in the destinated state.

            var state = dispatcher.Dispatch(new CurrentState());
            if (!string.IsNullOrEmpty(state))
            {
                // Event to trigger end of state events
                eventDispatcher.Dispatch(new StateTransitionDeclared(timeProvider.Now, command.ProcessId, state));
            }
            
            dispatcher.Dispatch(new ClearTemporaryActions());
            eventDispatcher.Dispatch(new EnteredState(timeProvider.Now, command.ProcessId, command.NewState));
            dispatcher.Dispatch(new ResolvePermanents());
        }
    }
}
