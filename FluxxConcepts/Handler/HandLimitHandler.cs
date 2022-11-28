using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.FluxxConcepts.Commands;
using System;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Handler
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

        public async Task Handle(HandLimit command, IEventDispatcher eventDispatcher)
        {
            // All inactive players discard
            var players = await dispatcher.Dispatch(new GetNumberOfPlayers());
            if (players == 0)
                return; // No players to discard from

            var currentPlayer = (await dispatcher.Dispatch(new CurrentPlayer()))?.Index ?? -1;

            for (int i = 0; i < players; i++)
            {
                if ((i + 1) != currentPlayer)
                {
                    var hand = await dispatcher.Dispatch(new GetPlayersHand(i + 1));
                    if (hand == null)
                        throw new Exception($"Player {i+1} has no hand. Remember to assign ownership for hands.");

                    await dispatcher.Dispatch(new DiscardDownTo(hand, command.Limit, command.DiscardPile));
                }
            }
        }
    }
}
