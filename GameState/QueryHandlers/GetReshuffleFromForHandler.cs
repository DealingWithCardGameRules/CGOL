using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.GameState.QueryHandlers
{
    public class GetReshuffleFromForHandler : IQueryHandler<GetReshuffleFromFor, string?>
    {
        private readonly ReshuffleRules reshuffleRules;

        internal GetReshuffleFromForHandler(ReshuffleRules reshuffleRules)
        {
            this.reshuffleRules = reshuffleRules ?? throw new System.ArgumentNullException(nameof(reshuffleRules));
        }

        public string? Handle(GetReshuffleFromFor query)
        {
            return reshuffleRules.GetRule(query.Destination);
        }
    }
}
