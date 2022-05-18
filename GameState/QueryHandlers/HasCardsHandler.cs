using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.GameState.QueryHandlers
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

        public bool Handle(HasCards query)
        {
            var collection = query.Collection ?? GetPlayerHand();
            if (collection == null)
                throw new Exception("No collection given and no player hand found. Remember to specify collection or up players and assign owners to hands.");
            return game.CollectionSize(collection) > 0;
        }

        private string? GetPlayerHand()
        {
            var player = dispatcher.Dispatch(new CurrentPlayer());
            if (player == null)
                throw new Exception("No collection given and no current player found. Remember to set collection or set up players.");
            return dispatcher.Dispatch(new GetPlayersHand(player.Index));
        }
    }
}
