using dk.itu.game.msc.cgdl.Distribution;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
{
    public class GetVisibleCards : IQuery<IEnumerable<ICard>>
    {
        public string Collection { get; set; }
        public IEnumerable<int> PlayerIndices { get; }

        public GetVisibleCards(string collection, IEnumerable<int>? playerIndex = null)
        {
            Collection = collection ?? throw new System.ArgumentNullException(nameof(collection));
            PlayerIndices = playerIndex ?? new int[0];
        }
    }
}
