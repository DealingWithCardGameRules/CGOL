using dk.itu.game.msc.cgdl.Distribution;
using dk.itu.game.msc.cgdl.FluxxConcepts.Queries;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Handler
{
    public class GetPlayLimitHandler : IQueryHandler<GetPlayLimit, int>
    {
        private readonly PlayerCounter playCounter;

        public GetPlayLimitHandler(PlayerCounter playCounter)
        {
            this.playCounter = playCounter ?? throw new System.ArgumentNullException(nameof(playCounter));
        }

        public int Handle(GetPlayLimit query)
        {
            return playCounter.GetLimit(query.PlayerIndex);
        }
    }
}
