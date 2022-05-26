using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.FluxxConcepts.Queries;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Handler
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
