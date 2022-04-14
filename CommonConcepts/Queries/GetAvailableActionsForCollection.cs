using dk.itu.game.msc.cgdl.CommandCentral;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
{
    public class GetAvailableActionsForCollection : IQuery<IEnumerable<IUserAction>>
    {
        public string Collection { get; set; }

        public GetAvailableActionsForCollection(string collection)
        {
            Collection = collection ?? throw new System.ArgumentNullException(nameof(collection));
        }
    }
}
