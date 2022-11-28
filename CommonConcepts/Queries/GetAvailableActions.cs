using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgol.CommonConcepts.Queries
{
    public class GetAvailableActions : IQuery<Func<IAsyncEnumerable<IUserAction>>>
    {
        public int? PlayerIndex { get; }

        [Concept(Description = "Get available player actions for a given player or all players if no player is specified.")]
        public GetAvailableActions(int? playerIndex = null)
        {
            PlayerIndex = playerIndex;
        }
    }
}
