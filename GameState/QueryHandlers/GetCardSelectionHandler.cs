using dk.itu.game.msc.cgol.Common.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgol.GameState.QueryHandlers
{
    public class GetCardSelectionHandler : IQueryHandler<GetCardSelection, IEnumerable<Guid>>
    {
        private readonly Game game;
        private readonly IQueryDispatcher dispatcher;

        internal GetCardSelectionHandler(Game game, IQueryDispatcher dispatcher)
        {
            this.game = game ?? throw new ArgumentNullException(nameof(game));
            this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        }

        public IEnumerable<Guid> Handle(GetCardSelection query)
        {
            return game.GetCards(query.Collection.Value(dispatcher), query.Tags).Select(c => c.Instance);
        }
    }
}
