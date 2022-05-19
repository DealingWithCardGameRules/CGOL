using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.Distribution;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
{
    public class GetCards : IQuery<IEnumerable<ICard>>
    {
        public string Collection { get; }
        public IEnumerable<string>? Tags { get; }

        [Concept(Description = "Get a list of cards from a specific collection. If tags are supplied only cards with those tags are returned.")]
        public GetCards(string collection, IEnumerable<string>? tags = null)
        {
            Collection = collection ?? throw new System.ArgumentNullException(nameof(collection));
            Tags = tags;
        }

    }
}
