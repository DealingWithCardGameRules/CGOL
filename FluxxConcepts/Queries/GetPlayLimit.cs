using dk.itu.game.msc.cgdl.CommandCentral;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Queries
{
    public class GetPlayLimit : IQuery<int>
    {
        public string? Player { get; }

        public GetPlayLimit(string player = null)
        {
            Player = player;
        }
    }
}
