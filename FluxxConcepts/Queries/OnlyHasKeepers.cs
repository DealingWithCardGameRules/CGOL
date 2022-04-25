using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts;
using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Queries
{
    public class OnlyHasKeepers : IQuery<bool>
    {
        public IEnumerable<string> Keepers { get; }
        public string? Collection { get; }

        [Concept(Description = "Check if a collection contains only the named comma seperated keepers. Use the unique card name states when the card was created. If collection is not supplied, a zone with the tag keepers assigned to the current player is used.")]
        public OnlyHasKeepers(string keepers, string collection = null)
        {
            Keepers = keepers.CommaSeperateTrimmed();
            Collection = collection;
        }
    }
}