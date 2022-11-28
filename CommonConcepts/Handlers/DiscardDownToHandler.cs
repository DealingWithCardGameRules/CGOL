using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.CommonConcepts.Handlers
{
    public class DiscardDownToHandler : ICommandHandler<DiscardDownTo>
    {
        private readonly IDispatcher dispatcher;

        public DiscardDownToHandler(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public async Task Handle(DiscardDownTo command, IEventDispatcher eventDispatcher)
        {
            var size = await dispatcher.Dispatch(new CardCount(command.From));
            var toDiscard = size - command.Size;
            if (toDiscard < 1)
                return;

            for(int i = 0; i < toDiscard; i++)
                await dispatcher.Dispatch(new DiscardCard(command.From, command.To));
        }
    }
}
