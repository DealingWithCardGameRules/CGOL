using dk.itu.game.msc.cgdl.Distribution;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
{
    public class GetAvailableActions : IQuery<IEnumerable<IUserAction>>
    {
        public int? PlayerIndex { get; }

        public GetAvailableActions(int? playerIndex = null)
        {
            PlayerIndex = playerIndex;
        }
    }
}
