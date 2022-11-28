using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgol.CommonConcepts.Queries
{
    public class GetCollectionNames : IQuery<Func<IAsyncEnumerable<string>>>
    {
        public IEnumerable<string>? WithTags { get; set; }
        public int? OwnedBy { get; set; }
    }
}
