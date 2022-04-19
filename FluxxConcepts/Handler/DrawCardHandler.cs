using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.CommonConcepts.Handlers;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.FluxxConcepts.Queries;
using System;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Handler
{
    public sealed class DrawCardHandler : ICommandHandler<DrawCard>
    {
        private readonly IDispatcher dispatcher;
        private readonly SimplyDrawCard drawCardHandler;

        public DrawCardHandler(ITimeProvider timeProvider, IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
            drawCardHandler = new SimplyDrawCard(timeProvider, dispatcher);
        }

        public void Handle(DrawCard command, IEventDispatcher eventDispatcher)
        {
            var player = dispatcher.Dispatch(new CurrentPlayer());
            if (player == null)
                throw new Exception("No current player. Remember to setup players.");
            if (!dispatcher.Dispatch(new DrawLimitReached(player.Identity)))
                drawCardHandler.Handle(command, eventDispatcher);
        }
    }
}
