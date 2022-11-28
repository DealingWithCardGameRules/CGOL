using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.FluxxConcepts.Queries;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Handler
{
    public class PlayLimitAboveHandler : IQueryHandler<PlayLimitAbove, bool>
    {
        private readonly IQueryDispatcher dispatcher;

        public PlayLimitAboveHandler(IQueryDispatcher dispatcher)
        {
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public async Task<bool> Handle(PlayLimitAbove query)
        {
            return await dispatcher.Dispatch(new GetPlayLimit()) > query.Limit;
        }
    }
}
