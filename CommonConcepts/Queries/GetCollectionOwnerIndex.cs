using dk.itu.game.msc.cgdl.CommandCentral;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
{
    public class GetCollectionOwnerIndex : IQuery<int?>
    {
        public string Collection { get; }

        public GetCollectionOwnerIndex(string collection)
        {
            Collection = collection;
        }
    }
}
