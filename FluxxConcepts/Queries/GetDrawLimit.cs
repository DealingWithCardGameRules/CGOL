using dk.itu.game.msc.cgdl.CommandCentral;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Queries
{
    public class GetDrawLimit : IQuery<int>
    {
        public string? Player { get; }

        public GetDrawLimit(string player = null)
        {
            Player = player;
        }
    }
}
