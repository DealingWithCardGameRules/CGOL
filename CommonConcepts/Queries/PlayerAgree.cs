using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.CommonConcepts.Queries
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
