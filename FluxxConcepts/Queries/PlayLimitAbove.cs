using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Queries
{
    public class PlayLimitAbove : IQuery<bool>
    {
        public int Limit { get; }

        public PlayLimitAbove(int limit)
        {
            Limit = limit;
        }
    }
}
