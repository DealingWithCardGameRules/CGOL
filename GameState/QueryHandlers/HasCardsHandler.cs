using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.GameState.QueryHandlers
{
    public class HasCardsHandler : IQueryHandler<HasCards, bool>
    {
        private readonly Game game;
        private readonly IQueryDispatcher dispatcher;

        internal HasCardsHandler(Game game, IQueryDispatcher dispatcher)
        {
            this.game = game ?? throw new ArgumentNullException(nameof(game));
            this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        }

        public async Task<bool> Handle(HasCards query)
        {
            var collection = query.Collection ?? await GetPlayerHand();
            if (collection == null)
                throw new Exception("No collection given and no player hand found. Remember to specify collection or up players and assign owners to hands.");
            return game.CollectionSize(collection) > 0;
        }

        private async Task<string?> GetPlayerHand()
        {
            var player = await dispatcher.Dispatch(new CurrentPlayer());
            if (player == null)
                throw new Exception("No collection given and no current player found. Remember to set collection or set up players.");
            return await dispatcher.Dispatch(new GetPlayersHand(player.Index));
        }
    }
}
