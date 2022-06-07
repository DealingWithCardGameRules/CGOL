using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.Common.Queries
{
    public class CurrentPlayersHand : IQuery<string>
    {
        [Concept(Description = "Get the name of current players hand. Fails if no players or current player does not have a hand.")]
        public CurrentPlayersHand()
        {

        }
    }
}
