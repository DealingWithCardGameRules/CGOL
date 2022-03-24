using dk.itu.game.msc.cgdl.CommandCentral;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Queries
{
    public class DrawLimitReached : IQuery<bool>
    {
        public string Player { get; }

        public DrawLimitReached(string player)
        {
            Player = player;
        }
    }
}
