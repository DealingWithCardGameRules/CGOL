using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.CommonConcepts.Handlers
{
    public class PostponeCommandHandler : ICommandHandler<PostponeCommand>
    {
        private readonly ITimeProvider timeProvider;

        public PostponeCommandHandler(ITimeProvider timeProvider)
        {
            this.timeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
        }

        public async Task Handle(PostponeCommand command, IEventDispatcher eventDispatcher)
        {
            if (command.SelfRef == null)
                await eventDispatcher.Dispatch(
                    new CommandPostponed(timeProvider.Now, command.ProcessId, command.Command, command.Label));
            else
                await eventDispatcher.Dispatch(
                    new CommandTemporarelyPostponed(timeProvider.Now, command.ProcessId, command.Command, command.Label));
        }
    }
}
