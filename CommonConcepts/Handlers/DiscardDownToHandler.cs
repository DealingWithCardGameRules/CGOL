using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
{
    public class DiscardDownToHandler : ICommandHandler<DiscardDownTo>
    {
        private readonly IDispatcher dispatcher;

        public DiscardDownToHandler(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public void Handle(DiscardDownTo command, IEventDispatcher eventDispatcher)
        {
            var size = dispatcher.Dispatch(new CardCount(command.From));
            var toDiscard = size - command.Size;
            if (toDiscard < 1)
                return;

            for(int i = 0; i < toDiscard; i++)
                dispatcher.Dispatch(new DiscardCard(command.From, command.To));
        }
    }
}
