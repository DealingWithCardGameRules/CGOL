using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.CommonConcepts.Queries
{
    public class HasNoCards : IQuery<bool>
    {
        public string? Collection { get; }

        public HasNoCards(string collection = null)
        {
            Collection = collection;
        }
    }
}
