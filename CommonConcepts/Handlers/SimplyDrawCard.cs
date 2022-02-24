using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
{
    public class SimplyDrawCard : ICommandHandler<DrawCard>
    {
        private readonly ITimeProvider timeProvider;

        public SimplyDrawCard(ITimeProvider timeProvider)
        {
            this.timeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
        }

        public void Handle(DrawCard command, IEventDispatcher eventDispatcher)
        {
            var @event = new CardDrawn(timeProvider.Now, command.ProcessId, command.Source, command.Destination);
            eventDispatcher.Dispatch(@event);
        }
    }
}
