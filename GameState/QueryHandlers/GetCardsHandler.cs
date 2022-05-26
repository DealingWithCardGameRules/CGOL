using dk.itu.game.msc.cgol.CommonConcepts;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgol.GameState.QueryHandlers
{
    public class GetCardsHandler : IQueryHandler<GetCards, IEnumerable<ICard>>
    {
        private readonly Game game;

        internal GetCardsHandler(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public IEnumerable<ICard> Handle(GetCards query)
        {
            return game.GetCards(query.Collection, query.Tags);
        }
    }
}
