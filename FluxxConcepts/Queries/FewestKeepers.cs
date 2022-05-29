using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Queries
{
    public class FewestKeepers : IQuery<bool>
    {
        [Concept(Description = "Check if the current player has the fewest number of keeper cards.")]
        public FewestKeepers()
        {

        }
    }
}
