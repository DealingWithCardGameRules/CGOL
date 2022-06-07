using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgol.Common.Queries
{
    public class GetCardSelection : IQuery<IEnumerable<Guid>>
    {
        public MaybeQuery<string> Collection { get; }
        public IEnumerable<string>? Tags { get; }

        public GetCardSelection(MaybeQuery<string> collection, IEnumerable<string>? tags = null)
        {
            Collection = collection ?? throw new ArgumentNullException(nameof(collection));
            Tags = tags;
        }
    }
}
