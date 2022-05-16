using dk.itu.game.msc.cgdl.Distribution;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
{
    public class GetAvailableActionsForCollection : IQuery<IEnumerable<IUserAction>>
    {
        public string Collection { get; set; }
        public int? PlayerIndex { get; }

        public GetAvailableActionsForCollection(string collection, int? playerIndex = null)
        {
            Collection = collection ?? throw new System.ArgumentNullException(nameof(collection));
            PlayerIndex = playerIndex;
        }
    }
}
