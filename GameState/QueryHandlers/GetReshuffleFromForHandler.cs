using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.GameState.QueryHandlers
{
    public class GetReshuffleFromForHandler : IQueryHandler<GetReshuffleFromFor, string?>
    {
        private readonly ReshuffleRules reshuffleRules;

        internal GetReshuffleFromForHandler(ReshuffleRules reshuffleRules)
        {
            this.reshuffleRules = reshuffleRules ?? throw new System.ArgumentNullException(nameof(reshuffleRules));
        }

        public async Task<string?> Handle(GetReshuffleFromFor query)
        {
            return reshuffleRules.GetRule(query.Destination);
        }
    }
}
