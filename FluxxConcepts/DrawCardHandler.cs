using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.CommonConcepts.Exceptions;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using System;

namespace dk.itu.game.msc.cgdl.FluxxConcepts
{
    public sealed class DrawCardHandler : ICommandHandler<DrawCard>
    {
        private readonly IQueryDispatcher dispatcher;

        public DrawCardHandler(IQueryDispatcher dispatcher)
        {
            this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        }

        public void Handle(DrawCard command, IEventDispatcher eventDispatcher)
        {
            if (!dispatcher.Dispatch(new HasCards(command.Source)))
                throw new NoCardsException(command.Source);

            ICard card = dispatcher.Dispatch(new GetTopCard(command.Source));
            eventDispatcher.Dispatch(new CardDrawn(DateTime.Now, command.ProcessId, command.Source, command.Destination, card.Instance));
        }
    }
}
