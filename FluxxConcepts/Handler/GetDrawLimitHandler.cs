using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.FluxxConcepts.Queries;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Handler
{
    public class GetDrawLimitHandler : IQueryHandler<GetDrawLimit, int>
    {
        private readonly PlayerCounter drawCounter;

        public GetDrawLimitHandler(PlayerCounter drawCounter)
        {
            this.drawCounter = drawCounter ?? throw new System.ArgumentNullException(nameof(drawCounter));
        }

        public int Handle(GetDrawLimit query)
        {
            return drawCounter.GetLimit(query.PlayerIndex);
        }
    }
}
