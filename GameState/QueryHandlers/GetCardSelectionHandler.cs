using dk.itu.game.msc.cgol.Common.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.GameState.QueryHandlers
{
    public class GetCardSelectionHandler : IQueryHandler<GetCardSelection, Func<IAsyncEnumerable<Guid>>>
    {
        private readonly Game game;
        private readonly IQueryDispatcher dispatcher;

        internal GetCardSelectionHandler(Game game, IQueryDispatcher dispatcher)
        {
            this.game = game ?? throw new ArgumentNullException(nameof(game));
            this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        }

        public async Task<Func<IAsyncEnumerable<Guid>>> Handle(GetCardSelection query)
        {
            async IAsyncEnumerable<Guid> Handler() 
            {
                foreach (var card in game.GetCards(await query.Collection.Value(dispatcher), query.Tags).Select(c => c.Instance))
                    yield return card;
            }

            return () => Handler();
        }

        Task<Func<IAsyncEnumerable<Guid>>> IQueryHandler<GetCardSelection, Func<IAsyncEnumerable<Guid>>>.Handle(GetCardSelection query)
        {
            throw new NotImplementedException();
        }
    }
}
