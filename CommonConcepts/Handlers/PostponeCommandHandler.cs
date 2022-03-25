using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
{
    public class PostponeCommandHandler : ICommandHandler<PostponeCommand>
    {
        private readonly ITimeProvider timeProvider;

        public PostponeCommandHandler(ITimeProvider timeProvider)
        {
            this.timeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
        }

        public void Handle(PostponeCommand command, IEventDispatcher eventDispatcher)
        {
            eventDispatcher.Dispatch(
                new CommandPostponed(timeProvider.Now, command.ProcessId, command.Command));
        }
    }
}
