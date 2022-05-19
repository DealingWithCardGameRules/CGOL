using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.Distribution;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
{
    public class GetVisibleCards : IQuery<IEnumerable<ICard>>
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
