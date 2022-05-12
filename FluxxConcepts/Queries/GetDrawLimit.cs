using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Queries
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
