using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.FluxxConcepts.Queries;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Handler
{
    public class CurrentPlayerHandler : IQueryHandler<CurrentPlayer, string>
    {
        public string Handle(CurrentPlayer query)
        {
            return "player1";
        }
    }
}
