using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Queries
{
    public class MostKeepers : IQuery<bool>
    {
        [Concept(Description = "Checks if the current player keepers zone holds the most keepers.")]
        public MostKeepers()
        {

        }
    }
}
