using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Queries
{
    public class PlayLimitReached : IQuery<bool>
    {
        public int PlayerIndex { get; }

        public PlayLimitReached(int playerIndex)
        {
            PlayerIndex = playerIndex;
        }
    }
}
