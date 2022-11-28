using dk.itu.game.msc.cgol.Common;
using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.CommonConcepts.Handlers
{
    public class ClaimOwnershipHandler : ICommandHandler<ClaimOwnership>
    {
        private readonly IDispatcher dispatcher;

        public ClaimOwnershipHandler(IDispatcher dispatcher)
        {
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public async Task Handle(ClaimOwnership command, IEventDispatcher eventDispatcher)
        {
            var collection = command.Collection ?? await GetPlayerHand();
            var ownerIndex = await dispatcher.Dispatch(new GetCollectionOwnerIndex(collection));
            if (!ownerIndex.HasValue)
                throw new Exception($"No owner found for collection {collection}. Remember to set an owner, for example using {nameof(CollectionOwner)}");
            var cards = await dispatcher.Dispatch(new GetCards(collection));
            await foreach (var card in cards())
                await dispatcher.Dispatch(new CardOwner(ownerIndex.Value, card.Instance));
        }

        private async Task<string> GetPlayerHand()
        {
            var player = await dispatcher.Dispatch(new CurrentPlayer());
            if (player == null)
                throw new Exception($"No collection given and no current player. Please supply collection or set up players using {nameof(SetPlayers)}");
            var hand = await dispatcher.Dispatch(new GetPlayersHand(player.Index));
            if (hand == null)
                throw new Exception($"No collection given and no hand for current player. Please supply collection or set up a player hand using {nameof(CreateHand)}");
            return hand;

        }
    }
}
