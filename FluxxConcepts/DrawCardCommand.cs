using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.CommonConcepts.Exceptions;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using System;

namespace dk.itu.game.msc.cgdl.FluxxConcepts
{
    public sealed class DrawCardCommandHandler : ICommandHandler<DrawCardCommand>
    {
        private readonly IQueryDispatcher dispatcher;

        public DrawCardCommandHandler(IQueryDispatcher dispatcher)
        {
            this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        }

        public void Handle(DrawCardCommand command, IEventDispatcher eventDispatcher)
        {
            if (!dispatcher.Dispatch(new HasCards(command.Source)))
                throw new NoCardsException(command.Source);

            eventDispatcher.Dispatch(new CardDrawnEvent(DateTime.Now, command.ProcessId, command.Source, command.Destination));
        }
    }
}
