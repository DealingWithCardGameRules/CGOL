using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Queries
{
    public class GetPlayLimit : IQuery<int>
    {
        public int? PlayerIndex { get; }

        public GetPlayLimit(int playerIndex = 0)
        {
            if (playerIndex > 0)
                PlayerIndex = playerIndex;
        }
    }
}
