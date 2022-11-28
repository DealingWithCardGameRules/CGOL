using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.Parser.Messages
{
    public class SimpleConditionalCommandHandler : ICommandHandler<ConditionalCommand>
    {
        private readonly IDispatcher dispatcher;

        public SimpleConditionalCommandHandler(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public async Task Handle(ConditionalCommand command, IEventDispatcher eventDispatcher)
        {
            if (await dispatcher.Dispatch(command.Query))
                await dispatcher.Dispatch(command.Command);
        }
    }
}
