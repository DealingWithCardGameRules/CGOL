using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using System;
using dk.itu.game.msc.cgdl.CommonConcepts.Handlers;
using dk.itu.game.msc.cgdl.FluxxConcepts.Queries;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Handler
{
    public class PlayCardHandler : ICommandHandler<PlayCard>
    {
        private readonly IDispatcher dispatcher;
        private SimplePlayCardHandler simplePlayCardHandler;

        public PlayCardHandler(ITimeProvider timeProvider, IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
            simplePlayCardHandler = new SimplePlayCardHandler(timeProvider, dispatcher);
        }

        public void Handle(PlayCard command, IEventDispatcher eventDispatcher)
        {
            var player = dispatcher.Dispatch(new CurrentPlayer());
            if (player == null)
                throw new Exception("No current player. In Fluxx players are required to keep track of play limit.");

            if (!dispatcher.Dispatch(new PlayLimitReached(player.Index)))
                simplePlayCardHandler.Handle(command, eventDispatcher);
        }
    }
}
