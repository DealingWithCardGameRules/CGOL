using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.FluxxConcepts.Queries;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Handler
{
    public class GetDrawLimitHandler : IQueryHandler<GetDrawLimit, int>
    {
        private readonly DrawCounter drawCounter;

        public GetDrawLimitHandler(DrawCounter drawCounter)
        {
            this.drawCounter = drawCounter ?? throw new System.ArgumentNullException(nameof(drawCounter));
        }

        public int Handle(GetDrawLimit query)
        {
            return drawCounter.GetDrawLimit(query.Player);
        }
    }
}
