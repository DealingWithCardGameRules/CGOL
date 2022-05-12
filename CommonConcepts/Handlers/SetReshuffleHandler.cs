using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
{
    public class SetReshuffleHandler : ICommandHandler<SetReshuffle>
    {
        private readonly ITimeProvider timeProvider;

        public SetReshuffleHandler(ITimeProvider timeProvider)
        {
            this.timeProvider = timeProvider;
        }

        public void Handle(SetReshuffle command, IEventDispatcher eventDispatcher)
        {
            eventDispatcher.Dispatch(new ReshuffleRuleSet(timeProvider.Now, command.ProcessId, command.From, command.To));
        }
    }
}
