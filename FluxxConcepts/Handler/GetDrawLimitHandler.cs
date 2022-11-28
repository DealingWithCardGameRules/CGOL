using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.FluxxConcepts.Queries;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Handler
{
    public class GetDrawLimitHandler : IQueryHandler<GetDrawLimit, int>
    {
        private readonly PlayerCounter drawCounter;

        public GetDrawLimitHandler(PlayerCounter drawCounter)
        {
            this.drawCounter = drawCounter ?? throw new System.ArgumentNullException(nameof(drawCounter));
        }

        public async Task<int> Handle(GetDrawLimit query)
        {
            return drawCounter.GetLimit(query.PlayerIndex);
        }
    }
}
