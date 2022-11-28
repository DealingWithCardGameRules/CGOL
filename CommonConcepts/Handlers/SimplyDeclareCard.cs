using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.CommonConcepts.Handlers
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

        public async Task Handle(CreateCard command, IEventDispatcher eventDispatcher)
        {
            if (await dispatcher.Dispatch(new GetTemplate(command.Template)) != null)
                return;
            
            var template = new SimpleTemplate(command.Template);
            var @event = new CardDeclared(timeProvider.Now, command.ProcessId, command.Template, template);
            await eventDispatcher.Dispatch(@event);            
        }
    }
}
