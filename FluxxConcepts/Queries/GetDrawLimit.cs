using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Queries
{
    public class GetDrawLimit : IQuery<int>
    {
        public int? PlayerIndex { get; }

        [Concept(Description = "Get the draw limit. If specified get the draw limit for a specific player.")]
        public GetDrawLimit(int player = 0)
        {
            if (player > 0)
                PlayerIndex = player;
        }
    }
}
