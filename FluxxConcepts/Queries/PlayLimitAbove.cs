using dk.itu.game.msc.cgdl.CommandCentral;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Queries
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
