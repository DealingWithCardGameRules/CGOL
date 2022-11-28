using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.FluxxConcepts.Queries;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Handler
{
    public class PlayLimitReachedHandler : IQueryHandler<PlayLimitReached, bool>
    {
        private readonly PlayerCounter playLimit;

        public PlayLimitReachedHandler(PlayerCounter playCounter)
        {
            this.playLimit = playCounter ?? throw new System.ArgumentNullException(nameof(playCounter));
        }

        public async Task<bool> Handle(PlayLimitReached query)
        {
            return playLimit.ReachedFor(query.PlayerIndex);
        }
    }
}
