using dk.itu.game.msc.cgdl.CommandCentral;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
{
    public class GetCollectionTags : IQuery<IEnumerable<string>>
    {
        public string Collection { get; set; }

        public GetCollectionTags(string collection)
        {
            Collection = collection ?? throw new System.ArgumentNullException(nameof(collection));
        }
    }
}
