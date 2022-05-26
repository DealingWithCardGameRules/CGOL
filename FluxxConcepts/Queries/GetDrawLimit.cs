using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Queries
{
    public class GetDrawLimit : IQuery<int>
    {
        public int? PlayerIndex { get; }

        public GetDrawLimit(int player = 0)
        {
            if (player > 0)
                PlayerIndex = player;
        }
    }
}
