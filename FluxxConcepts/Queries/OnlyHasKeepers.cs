using dk.itu.game.msc.cgol.CommonConcepts;
using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Queries
{
    public class OnlyHasKeepers : IQuery<bool>
    {
        public IEnumerable<string> Keepers { get; }
        public string? Collection { get; }

        [Concept(Description = "Check if a collection contains only the named comma separated keepers. Use the unique card name states when the card was created. If collection is not supplied, a zone with the tag keepers assigned to the current player is used.")]
        public OnlyHasKeepers(string keepers, string collection = null)
        {
            Keepers = keepers.CommaSeperateTrimmed();
            Collection = collection;
        }
    }
}