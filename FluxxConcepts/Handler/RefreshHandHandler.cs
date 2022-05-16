using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.Distribution;
using dk.itu.game.msc.cgdl.FluxxConcepts.Commands;
using System;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Handler
{
    public class RefreshHandHandler : ICommandHandler<RefreshHand>
    {
        private readonly IDispatcher dispatcher;

        public RefreshHandHandler(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        }

        public void Handle(RefreshHand command, IEventDispatcher eventDispatcher)
        {
            var hand = dispatcher.Dispatch(new GetPlayersHand());
            if (hand == null)
                throw new Exception("No current player hand found.");

            var reward = command.FixedReward ?? dispatcher.Dispatch(new CardCount(hand));
            dispatcher.Dispatch(new DiscardCards(hand, command.DiscardCollection));
            dispatcher.Dispatch(new DealCard(command.RewardCollection, reward));
        }
    }
}
