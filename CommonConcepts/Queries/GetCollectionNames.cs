using dk.itu.game.msc.cgdl.CommandCentral;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
{
    public class GetCollectionNames : IQuery<IEnumerable<string>>
    {
        public IEnumerable<string>? WithTags { get; set; }
    }
}
