using dk.itu.game.msc.cgdl.CommandCentral;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Queries
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
