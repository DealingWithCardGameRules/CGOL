using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using System;
using dk.itu.game.msc.cgol.CommonConcepts.Handlers;
using dk.itu.game.msc.cgol.FluxxConcepts.Queries;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Handler
{
    public class PlayCardHandler : ICommandHandler<PlayCard>
    {
        private readonly ICommandHandler<PlayCard> decoratee;
        private readonly IDispatcher dispatcher;
        
        public PlayCardHandler(ICommandHandler<PlayCard> decoratee, IDispatcher dispatcher)
        {
            this.decoratee = decoratee ?? throw new ArgumentNullException(nameof(decoratee));
            this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
                }

        public void Handle(PlayCard command, IEventDispatcher eventDispatcher)
        {
            var player = dispatcher.Dispatch(new CurrentPlayer());
            if (player == null)
                throw new Exception("No current player. In Fluxx players are required to keep track of play limit.");

            if (!dispatcher.Dispatch(new PlayLimitReached(player.Index)))
                decoratee.Handle(command, eventDispatcher);
        }
    }
}
