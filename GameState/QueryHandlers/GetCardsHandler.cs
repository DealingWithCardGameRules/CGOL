using dk.itu.game.msc.cgdl.CommonConcepts;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.Distribution;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.GameState.QueryHandlers
{
    public class GetCardsHandler : IQueryHandler<GetCards, IEnumerable<ICard>>
    {
        private readonly Game game;

        public GetCardsHandler(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public IEnumerable<ICard> Handle(GetCards query)
        {
            return game.GetCards(query.Collection, query.Tags);
        }
    }
}
