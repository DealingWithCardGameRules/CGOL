using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.Representation.Observers
{
    public class PlayerWonObserver : IEventObserver<PlayerWon>
    {
        private readonly IUserEnquirer userEnquirer;

        public PlayerWonObserver(IUserEnquirer userEnquirer)
        {
            this.userEnquirer = userEnquirer ?? throw new System.ArgumentNullException(nameof(userEnquirer));
        }

        public async Task Invoke(PlayerWon @event)
        {
            var winner = @event.PlayerIndex == null ? "You" : $"Player {@event.PlayerIndex}";
            userEnquirer.SendConclusion($"{winner} won the game.");
        }
    }
}
