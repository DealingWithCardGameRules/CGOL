using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Queries
{
    public class PlayLimitAbove : IQuery<bool>
    {
        public int Limit { get; }

        [Concept(Description = "Check if the current play limit is above the specified value.")]
        public PlayLimitAbove(int limit)
        {
            Limit = limit;
        }
    }
}
