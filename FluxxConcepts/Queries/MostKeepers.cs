using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Queries
{
    public class MostKeepers : IQuery<bool>
    {
        [Concept(Description = "Checks if the current player's keepers zone holds most keepers.")]
        public MostKeepers()
        {

        }
    }
}
