using dk.itu.game.msc.cgdl.Distribution;
using dk.itu.game.msc.cgdl.FluxxConcepts.Queries;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Handler
{
    public class PlayLimitAboveHandler : IQueryHandler<PlayLimitAbove, bool>
    {
        private readonly IQueryDispatcher dispatcher;

        public PlayLimitAboveHandler(IQueryDispatcher dispatcher)
        {
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public bool Handle(PlayLimitAbove query)
        {
            return dispatcher.Dispatch(new GetPlayLimit()) > query.Limit;
        }
    }
}
