using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;

namespace dk.itu.game.msc.cgdl.Representation.Observers
{
    public class PlayerWonObserver : IEventObserver<PlayerWon>
    {
        private readonly IUserEnquirer userEnquirer;

        public PlayerWonObserver(IUserEnquirer userEnquirer)
        {
            this.userEnquirer = userEnquirer ?? throw new System.ArgumentNullException(nameof(userEnquirer));
        }

        public void Invoke(PlayerWon @event)
        {
            var winner = @event.PlayerIndex == null ? "You" : $"Player {@event.PlayerIndex}";
            userEnquirer.SendConclusion($"{winner} won the game.");
        }
    }
}
