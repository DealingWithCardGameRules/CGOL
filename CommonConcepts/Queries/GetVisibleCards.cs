using dk.itu.game.msc.cgdl.CommandCentral;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
{
    public class GetVisibleCards : IQuery<IEnumerable<ICard>>
    {
        public string Collection { get; set; }
        public IEnumerable<int> PlayerIndexes { get; }

        public GetVisibleCards(string collection, IEnumerable<int>? playerIndex = null)
        {
            Collection = collection ?? throw new System.ArgumentNullException(nameof(collection));
            PlayerIndexes = playerIndex ?? new int[0];
        }
    }
}
