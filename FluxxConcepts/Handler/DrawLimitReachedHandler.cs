using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.FluxxConcepts.Queries;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Handler
{
    public class DrawLimitReachedHandler : IQueryHandler<DrawLimitReached, bool>
    {
        private readonly PlayerCounter drawLimit;

        public DrawLimitReachedHandler(PlayerCounter drawLimit)
        {
            this.drawLimit = drawLimit ?? throw new System.ArgumentNullException(nameof(drawLimit));
        }

        public bool Handle(DrawLimitReached query)
        {
            return drawLimit.ReachedFor(query.PlayerIndex);
        }
    }
}
