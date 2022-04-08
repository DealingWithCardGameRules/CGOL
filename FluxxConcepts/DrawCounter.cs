using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.FluxxConcepts
{
    public class DrawCounter
    {
        private Dictionary<string, int> drawCounter;
        private int drawLimit = 0;

        public DrawCounter()
        {
            drawCounter = new Dictionary<string, int>();
        }

        internal void SetDrawLimit(int limit)
        {
            drawLimit = limit;
        }

        internal bool ReachedFor(string player)
        {
            return drawLimit != 0 && GetPlayer(player) >= drawLimit;
        }

        internal int GetDrawLimit(string? player)
        {
            return drawLimit; // Currently the same for all players
        }

        internal void ResetPlayer(string player)
        {
            drawCounter[player] = 0;
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