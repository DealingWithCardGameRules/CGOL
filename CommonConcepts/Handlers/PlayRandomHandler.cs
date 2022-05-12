using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
{
    public class PlayRandomHandler : ICommandHandler<PlayRandom>
    {
        private readonly IDispatcher dispatcher;

        public PlayRandomHandler(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        }

        public void Handle(PlayRandom command, IEventDispatcher eventDispatcher)
        {
            var collection = command.Collection ?? GetPlayersHand();
            var card = dispatcher.Dispatch(new GetRandomCard(collection));
            if (card == null)
                throw new Exception("No cards in collection.");
            dispatcher.Dispatch(new PlayCard(command.Collection, card: card.Instance));
        }

        private string GetPlayersHand()
        {
            var player = dispatcher.Dispatch(new CurrentPlayer());
            if (player == null)
                throw new Exception("No collection specified and no players setup. Remember to set up players.");
            var hand = dispatcher.Dispatch(new GetPlayersHand(player.Index));
            if (hand == null)
                throw new Exception("No collection specified and no hand found for current player. Remember to assign hands to playeres.");
            return hand;
        }
    }
}
