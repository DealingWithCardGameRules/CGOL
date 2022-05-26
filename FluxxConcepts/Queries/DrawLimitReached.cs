using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Queries
{
    public class DrawLimitReached : IQuery<bool>
    {
        public int PlayerIndex { get; }

        public DrawLimitReached(int playerIndex)
        {
            PlayerIndex = playerIndex;
        }
    }
}
