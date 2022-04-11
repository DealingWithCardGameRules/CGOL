using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
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
            var owner = game.GetCollectionOwner(query.Collection);
            if (owner != null && query.PlayerIndexes.Contains(owner.Value))
                foreach (var card in game.GetRevieledCards(query.Collection))
                    yield return card;
        }
    }
}
