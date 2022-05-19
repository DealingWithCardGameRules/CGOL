using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
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
