using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.CommonConcepts.Queries
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
