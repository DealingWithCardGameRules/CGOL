using dk.itu.game.msc.cgdl.Distribution;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
{
    public class GetCards : IQuery<IEnumerable<ICard>>
    {
        public string Collection { get; }
        public IEnumerable<string>? Tags { get; }

        public GetCards(string collection, IEnumerable<string>? tags = null)
        {
            Collection = collection ?? throw new System.ArgumentNullException(nameof(collection));
            Tags = tags;
        }

    }
}
