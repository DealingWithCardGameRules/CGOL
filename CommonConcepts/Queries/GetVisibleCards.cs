using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgol.CommonConcepts.Queries
{
    public class GetVisibleCards : IQuery<Func<IAsyncEnumerable<ICard>>>
    {
        public string Collection { get; set; }
        public IEnumerable<int> PlayerIndices { get; }

        [Concept(Description = "Get cards from a specific collection that are visible for a specific player or anyone if player is not set.")]
        public GetVisibleCards(string collection, IEnumerable<int>? playerIndex = null)
        {
            Collection = collection ?? throw new System.ArgumentNullException(nameof(collection));
            PlayerIndices = playerIndex ?? new int[0];
        }
    }
}
