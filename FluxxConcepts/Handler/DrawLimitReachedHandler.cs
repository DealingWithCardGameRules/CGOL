using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.FluxxConcepts.Queries;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Handler
{
    public class DrawLimitReachedHandler : IQueryHandler<DrawLimitReached, bool>
    {
        private readonly DrawCounter drawLimit;

        public DrawLimitReachedHandler(DrawCounter drawLimit)
        {
            this.drawLimit = drawLimit;
        }

        public bool Handle(DrawLimitReached query)
        {
            return drawLimit.ReachedFor(query.Player);
        }
    }
}
