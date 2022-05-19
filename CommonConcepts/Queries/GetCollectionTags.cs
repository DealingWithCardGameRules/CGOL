using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.Distribution;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
{
    public class GetCollectionTags : IQuery<IEnumerable<string>>
    {
        public string Collection { get; set; }

        [Concept(Description = "Get a list of tags for a specific collection.")]
        public GetCollectionTags(string collection)
        {
            Collection = collection ?? throw new System.ArgumentNullException(nameof(collection));
        }
    }
}
