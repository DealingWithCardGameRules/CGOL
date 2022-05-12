using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
{
    public class SimplyDeclareZone : ICommandHandler<CreateZone>
    {
        private readonly ITimeProvider timeProvider;

        public SimplyDeclareZone(ITimeProvider timeProvider)
        {
            this.timeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
        }

        public void Handle(CreateZone command, IEventDispatcher eventDispatcher)
        {
            eventDispatcher.Dispatch(new ZoneDeclared(timeProvider.Now, command.ProcessId, command.Name, command.PlayerIndex));
            if (command.Tags != null)
                eventDispatcher.Dispatch(new TagsAddedToCollection(timeProvider.Now, command.ProcessId, command.Name, command.Tags.CommaSeperateTrimmed()));
        }
    }
}
