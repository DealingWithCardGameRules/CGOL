using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Queries
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
