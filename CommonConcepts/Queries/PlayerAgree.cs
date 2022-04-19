using dk.itu.game.msc.cgdl.CommandCentral;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
{
    public class PlayerAgree : IQuery<bool>
    {
        public int PlayerIndex { get; }
        public string Message { get; }
        public int TimeoutLimitSeconds { get; set; } = 600; // Ten minutes

        public PlayerAgree(int playerIndex, string message)
        {
            PlayerIndex = playerIndex;
            Message = message;
        }
    }
}
