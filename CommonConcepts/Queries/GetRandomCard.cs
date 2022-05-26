using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.CommonConcepts.Queries
{
    public class GetRandomCard : IQuery<ICard?>
    {
        public string Collection { get; }

        [Concept(Description = "Try to get a random card from a specific collection.")]
        public GetRandomCard(string collection)
        {
            Collection = collection;
        }
    }
}
