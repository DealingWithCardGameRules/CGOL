using dk.itu.game.msc.cgdl.CommandCentral;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Queries
{
    public class PlayLimitReached : IQuery<bool>
    {
        public string Player { get; }

        public PlayLimitReached(string player)
        {
            Player = player;
        }
    }
}
