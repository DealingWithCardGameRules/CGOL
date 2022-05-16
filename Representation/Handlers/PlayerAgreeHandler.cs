using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgdl.Representation.Handlers
{
    public class PlayerAgreeHandler : IQueryHandler<PlayerAgree, bool>
    {
        private const int secondsToMiliseconds = 100;
        private readonly IUserEnquirer enquirer;

        public PlayerAgreeHandler(IUserEnquirer enquirer)
        {
            this.enquirer = enquirer ?? throw new System.ArgumentNullException(nameof(enquirer));
        }

        public bool Handle(PlayerAgree query)
        {
            bool result = false;
            Task.Run(() => result = enquirer.AskPlayer(query.PlayerIndex, query.Message))
                .Wait(query.TimeoutLimitSeconds * secondsToMiliseconds);
            return result;
        }
    }
}
