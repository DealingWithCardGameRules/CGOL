using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
{
    public class GetPlayersHand : IQuery<string?>
    {
        public int? PlayerIndex { get; }

        [Concept(Description = "Get the name of the hand for a player. If no player is specified the current player is assumed.")]
        public GetPlayersHand(int? playerIndex = 0)
        {
            if (playerIndex > 0)
                PlayerIndex = playerIndex;
        }
    }
}
