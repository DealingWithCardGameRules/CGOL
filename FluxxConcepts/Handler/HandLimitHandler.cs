using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.Distribution;
using dk.itu.game.msc.cgdl.FluxxConcepts.Commands;
using System;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Handler
{
    public class HandLimitHandler : ICommandHandler<HandLimit>
    {
        private readonly ITimeProvider timeProvider;
        private readonly IDispatcher dispatcher;

        public HandLimitHandler(ITimeProvider timeProvider, IDispatcher dispatcher)
        {
            this.timeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public void Handle(HandLimit command, IEventDispatcher eventDispatcher)
        {
            // All inactive players discard
            var players = dispatcher.Dispatch(new GetNumberOfPlayers());
            if (players == 0)
                return; // No players to discard from

            var currentPlayer = dispatcher.Dispatch(new CurrentPlayer())?.Index ?? -1;

            for (int i = 0; i < players; i++)
            {
                if ((i + 1) != currentPlayer)
                {
                    var hand = dispatcher.Dispatch(new GetPlayersHand(i + 1));
                    if (hand == null)
                        throw new Exception($"Player {i+1} has no hand. Remember to assign ownership for hands.");

                    dispatcher.Dispatch(new DiscardDownTo(hand, command.Limit, command.DiscardPile));
                }
            }
        }
    }
}
