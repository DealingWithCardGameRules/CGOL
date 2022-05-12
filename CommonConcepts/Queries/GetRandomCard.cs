using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
{
    public class GetRandomCard : IQuery<ICard?>
    {
        public string Collection { get; }

        public GetRandomCard(string collection)
        {
            Collection = collection;
        }
    }
}
