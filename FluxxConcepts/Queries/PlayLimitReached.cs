using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Queries
{
    public class PlayLimitReached : IQuery<bool>
    {
        public int PlayerIndex { get; }

        [Concept(Description = "Check if the current player has reached or exceeded the play limit.")]
        public PlayLimitReached(int playerIndex)
        {
            PlayerIndex = playerIndex;
        }
    }
}
