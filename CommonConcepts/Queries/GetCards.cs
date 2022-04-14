using dk.itu.game.msc.cgdl.CommandCentral;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
{
    public class GetCards : IQuery<IEnumerable<ICard>>
    {
        public GetCards(string collection)
        {

        }
    }
}
