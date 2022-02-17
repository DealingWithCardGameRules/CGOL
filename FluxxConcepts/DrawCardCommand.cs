using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using System;

namespace dk.itu.game.msc.cgdl.FluxxConcepts
{
    public sealed class DrawCardCommandHandler : ICommandHandler<DrawCardCommand>
    {
        private readonly Messages messages;

        public DrawCardCommandHandler(Messages messages)
        {
            this.messages = messages;
        }

        public void Handle(DrawCardCommand command, IEventDispatcher eventDispatcher)
        {
            if (!messages.Dispatch(new HasCards(command.Source)))
            {
                throw new NoCardsException(command.Source);
            }
            eventDispatcher.Dispatch(new CardDrawnEvent(DateTime.Now, command.ProcessId, command.Source, command.Destination));
        }
    }
}
