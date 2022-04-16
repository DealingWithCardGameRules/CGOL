using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.FluxxConcepts.Queries;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Handler
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
            return drawCounter.GetLimit(query.Player);
        }
    }
}
