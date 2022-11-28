using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.CommonConcepts.Handlers
{
    public class SimplyDeclareZone : ICommandHandler<CreateZone>
    {
        private readonly ITimeProvider timeProvider;

        public SimplyDeclareZone(ITimeProvider timeProvider)
        {
            this.timeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
        }

        public async Task Handle(CreateZone command, IEventDispatcher eventDispatcher)
        {
            await eventDispatcher.Dispatch(new ZoneDeclared(timeProvider.Now, command.ProcessId, command.Name, command.PlayerIndex));
            if (command.Tags != null)
                await eventDispatcher.Dispatch(new TagsAddedToCollection(timeProvider.Now, command.ProcessId, command.Name, command.Tags.CommaSeperateTrimmed()));
        }
    }
}
