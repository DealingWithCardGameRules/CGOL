using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
{
    public class SimplyDeclareCard : ICommandHandler<CreateCard>
    {
        private readonly ITimeProvider timeProvider;
        private readonly IDispatcher dispatcher;

        public SimplyDeclareCard(ITimeProvider timeProvider, IDispatcher dispatcher)
        {
            this.timeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public void Handle(CreateCard command, IEventDispatcher eventDispatcher)
        {
            if (dispatcher.Dispatch(new GetTemplate(command.Template)) != null)
                return;
            
            var template = new SimpleTemplate(command.Template);
            var @event = new CardDeclared(timeProvider.Now, command.ProcessId, command.Template, template);
            eventDispatcher.Dispatch(@event);            
        }
    }
}
