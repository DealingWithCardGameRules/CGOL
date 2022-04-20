using dk.itu.game.msc.cgdl.CommandCentral;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Queries
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
