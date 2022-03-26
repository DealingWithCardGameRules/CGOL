using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Handler
{
    public class DrawCounter
    {
        private Dictionary<string, int> drawCounter;
        private int drawLimit = 2;

        public DrawCounter()
        {
            drawCounter = new Dictionary<string, int>();
        }

        internal bool ReachedFor(string player)
        {
            return GetPlayer(player) >= drawLimit;
        }

        internal void Aggregate(string player)
        {
            drawCounter[player] = GetPlayer(player) + 1;
        }

        private int GetPlayer(string player)
        {
            if (!drawCounter.ContainsKey(player))
                drawCounter[player] = 0;
            return drawCounter[player];
        }
    }
}