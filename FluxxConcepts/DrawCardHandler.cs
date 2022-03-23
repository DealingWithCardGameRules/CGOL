using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.CommonConcepts.Exceptions;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.FluxxConcepts.Queries;
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

            var player = dispatcher.Dispatch(new CurrentPlayer());

            while (!dispatcher.Dispatch(new DrawLimitReached(player)))
            {
                eventDispatcher.Dispatch(new CardDrawn(DateTime.Now, command.ProcessId, command.Source, command.Destination));
            }
        }
    }
}
