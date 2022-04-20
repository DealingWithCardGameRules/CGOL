using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.FluxxConcepts.Commands;
using dk.itu.game.msc.cgdl.FluxxConcepts.Events;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Handler
{
    public class SetRecycleHandler : ICommandHandler<SetRecycle>
    {
        private readonly ITimeProvider timeProvider;

        public SetRecycleHandler(ITimeProvider timeProvider)
        {
            this.timeProvider = timeProvider;
        }

        public void Handle(SetRecycle command, IEventDispatcher eventDispatcher)
        {
            eventDispatcher.Dispatch(new RecycleRuleSet(timeProvider.Now, command.ProcessId, command.From, command.To));
        }
    }
}
