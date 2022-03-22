using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
{
    public class SimplyDeclareCard : ICommandHandler<CreateCard>
    {
        private readonly ITimeProvider timeProvider;

        public SimplyDeclareCard(ITimeProvider timeProvider)
        {
            this.timeProvider = timeProvider;
        }

        public void Handle(CreateCard command, IEventDispatcher eventDispatcher)
        {
            var template = new SimpleTemplate(command.Template);
            var @event = new CardDeclared(timeProvider.Now, command.ProcessId, command.Template, template);
            eventDispatcher.Dispatch(@event);
        }
    }
}
