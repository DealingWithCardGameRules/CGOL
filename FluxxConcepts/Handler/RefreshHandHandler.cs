using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.FluxxConcepts.Commands;
using System;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Handler
{
    public class RefreshHandHandler : ICommandHandler<RefreshHand>
    {
        private readonly IDispatcher dispatcher;

        public RefreshHandHandler(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        }

        public async Task Handle(RefreshHand command, IEventDispatcher eventDispatcher)
        {
            var hand = await dispatcher.Dispatch(new GetPlayersHand());
            if (hand == null)
                throw new Exception("No current player hand found.");

            var reward = command.FixedReward ?? await dispatcher.Dispatch(new CardCount(hand));
            await dispatcher.Dispatch(new DiscardCards(hand, command.DiscardCollection));
            await dispatcher.Dispatch(new DealCard(command.RewardCollection, reward));
        }
    }
}
