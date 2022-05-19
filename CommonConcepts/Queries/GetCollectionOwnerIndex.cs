using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
{
    public class GetCollectionOwnerIndex : IQuery<int?>
    {
        public string Collection { get; }

        [Concept(Description = "Try to get the player index of a specific collection.")]
        public GetCollectionOwnerIndex(string collection)
        {
            Collection = collection;
        }
    }
}
