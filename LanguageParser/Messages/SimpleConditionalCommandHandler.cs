using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.Parser.Messages
{
    public class SimpleConditionalCommandHandler : ICommandHandler<ConditionalCommand>
    {
        private readonly IDispatcher dispatcher;

        public SimpleConditionalCommandHandler(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public void Handle(ConditionalCommand command, IEventDispatcher eventDispatcher)
        {
            if (dispatcher.Dispatch(command.Query))
                dispatcher.Dispatch(command.Command);
        }
    }
}
