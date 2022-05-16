using dk.itu.game.msc.cgdl.CommonConcepts;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.Distribution;
using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgdl.GameState.QueryHandlers
{
    public class GetVisibleCardsHandler : IQueryHandler<GetVisibleCards, IEnumerable<ICard>>
    {
        private readonly Game game;

        public GetVisibleCardsHandler(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public IEnumerable<ICard> Handle(GetVisibleCards query)
        {
            return game.GetRevieledCards(query.Collection, query.PlayerIndices);
        }
    }
}
