using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.GameState.QueryHandlers
{
    public class HasCollectionHandler : IQueryHandler<HasCollection, bool>
    {
        private readonly Game game;

        internal HasCollectionHandler(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public async Task<bool> Handle(HasCollection query)
        {
            return game.HasCollection(query.Name);
        }
    }
}
