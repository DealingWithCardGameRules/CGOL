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
        private readonly RecycleRules recycleRules;
        private readonly SimplyDrawCard drawCardHandler;

        public DrawCardHandler(ITimeProvider timeProvider, IDispatcher dispatcher, RecycleRules recycleRules)
        {
            this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
            this.recycleRules = recycleRules ?? throw new ArgumentNullException(nameof(recycleRules));
            drawCardHandler = new SimplyDrawCard(timeProvider, dispatcher);
        }

        public void Handle(DrawCard command, IEventDispatcher eventDispatcher)
        {
            var player = dispatcher.Dispatch(new CurrentPlayer());
            if (player == null)
                throw new Exception("No current player. Remember to setup players.");
            if (!dispatcher.Dispatch(new DrawLimitReached(player.Index)))
            {
                if (!dispatcher.Dispatch(new HasCards(command.Source)))
                    recycleRules.ApplyRule(command.Source, (from, to) => dispatcher.Dispatch(new ShuffleInto(from, to)));

                drawCardHandler.Handle(command, eventDispatcher);
                dispatcher.Dispatch(new ClaimOwnership());
            }
        }
    }
}
