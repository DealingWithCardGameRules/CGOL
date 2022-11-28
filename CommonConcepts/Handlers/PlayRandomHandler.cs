using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.CommonConcepts.Handlers
{
    public class PlayRandomHandler : ICommandHandler<PlayRandom>
    {
        private readonly IDispatcher dispatcher;

        public PlayRandomHandler(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        }

        public async Task Handle(PlayRandom command, IEventDispatcher eventDispatcher)
        {
            var collection = command.Collection ?? await GetPlayersHand();
            var card = await dispatcher.Dispatch(new GetRandomCard(collection));
            if (card == null)
                throw new Exception("No cards in collection.");
            await dispatcher.Dispatch(new PlayCard(command.Collection, card: card.Instance));
        }

        private async Task<string> GetPlayersHand()
        {
            var player = await dispatcher.Dispatch(new CurrentPlayer());
            if (player == null)
                throw new Exception("No collection specified and no players setup. Remember to set up players.");
            var hand = await dispatcher.Dispatch(new GetPlayersHand(player.Index));
            if (hand == null)
                throw new Exception("No collection specified and no hand found for current player. Remember to assign hands to playeres.");
            return hand;
        }
    }
}
