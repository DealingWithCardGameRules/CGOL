using dk.itu.game.msc.cgdl.CommandCentral;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
{
    public class GetVisibleCards : IQuery<IEnumerable<ICard>>
    {
        public string Collection { get; set; }

        public GetVisibleCards(string collection)
        {
            Collection = collection ?? throw new System.ArgumentNullException(nameof(collection));
        }
    }
}
