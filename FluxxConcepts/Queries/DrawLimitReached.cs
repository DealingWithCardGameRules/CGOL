using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Queries
{
    public class DrawLimitReached : IQuery<bool>
    {
        public int PlayerIndex { get; }

        [Concept(Description = "Check if the current player has reached or exceeded the draw limit.")]
        public DrawLimitReached(int playerIndex)
        {
            PlayerIndex = playerIndex;
        }
    }
}
