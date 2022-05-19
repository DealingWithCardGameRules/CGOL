using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.Distribution;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
{
    public class GetAvailableActions : IQuery<IEnumerable<IUserAction>>
    {
        public int? PlayerIndex { get; }

        [Concept(Description = "Get available player actions for a given player or all players if no player is specified.")]
        public GetAvailableActions(int? playerIndex = null)
        {
            PlayerIndex = playerIndex;
        }
    }
}
