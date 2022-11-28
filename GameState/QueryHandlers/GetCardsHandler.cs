using dk.itu.game.msc.cgol.CommonConcepts;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.GameState.QueryHandlers
{
    public class GetCardsHandler : IQueryHandler<GetCards, Func<IAsyncEnumerable<ICard>>>
    {
        private readonly Game game;

        internal GetCardsHandler(Game game)
        {
            this.game = game ?? throw new ArgumentNullException(nameof(game));
        }

        public async Task<Func<IAsyncEnumerable<ICard>>> Handle(GetCards query)
        {
            async IAsyncEnumerable<ICard> Handler()
            {
                foreach (var card in game.GetCards(query.Collection, query.Tags))
                {
                    yield return card;
                }
            }
                
            return () => Handler();
        }
    }
}
