using dk.itu.game.msc.cgdl.CommandCentral;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
{
    public class GetPlayersHand : IQuery<string?>
    {
        public int? PlayerIndex { get; }

        public GetPlayersHand(int? playerIndex = 0)
        {
            if (playerIndex > 0)
                PlayerIndex = playerIndex;
        }
    }
}
