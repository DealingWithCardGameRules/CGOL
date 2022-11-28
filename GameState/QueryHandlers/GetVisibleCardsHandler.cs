using dk.itu.game.msc.cgol.CommonConcepts;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.GameState.QueryHandlers
{
    public class GetVisibleCardsHandler : IQueryHandler<GetVisibleCards, Func<IAsyncEnumerable<ICard>>>
    {
        private readonly Game game;

        internal GetVisibleCardsHandler(Game game)
        {
            this.game = game ?? throw new ArgumentNullException(nameof(game));
        }

        public async Task<Func<IAsyncEnumerable<ICard>>> Handle(GetVisibleCards query)
        {
            async IAsyncEnumerable<ICard> Handler()
            {
                foreach (var cards in game.GetRevieledCards(query.Collection, query.PlayerIndices))
                    yield return cards;
            }

            return () => Handler();
        }
    }
}
