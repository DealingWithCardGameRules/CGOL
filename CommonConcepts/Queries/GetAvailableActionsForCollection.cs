using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgol.CommonConcepts.Queries
{
    public class GetAvailableActionsForCollection : IQuery<Func<IAsyncEnumerable<IUserAction>>>
    {
        public string Collection { get; set; }
        public int? PlayerIndex { get; }

        [Concept(Description = "Get available player actions for a given collection, for a given player or all players if no player is specified.")]
        public GetAvailableActionsForCollection(string collection, int? playerIndex = null)
        {
            Collection = collection ?? throw new System.ArgumentNullException(nameof(collection));
            PlayerIndex = playerIndex;
        }
    }
}
