using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Queries
{
    public class GetPlayLimit : IQuery<int>
    {
        public int? PlayerIndex { get; }

        [Concept(Description = "Get the play limit. If specified, get the play limit for a specific player.")]
        public GetPlayLimit(int playerIndex = 0)
        {
            if (playerIndex > 0)
                PlayerIndex = playerIndex;
        }
    }
}
