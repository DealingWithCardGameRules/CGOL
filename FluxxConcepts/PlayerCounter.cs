using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.FluxxConcepts
{
    public class PlayerCounter
    {
        private Dictionary<string, int> counter;
        private int limit = 0;

        public PlayerCounter()
        {
            counter = new Dictionary<string, int>();
        }

        internal void SetLimit(int limit)
        {
            this.limit = limit;
        }

        internal bool ReachedFor(string player)
        {
            return limit != 0 && GetPlayer(player) >= limit;
        }

        internal int GetLimit(string? player)
        {
            return limit; // Currently the same for all players
        }

        internal void ResetPlayer(string player)
        {
            counter[player] = 0;
        }

        internal void Aggregate(string player)
        {
            counter[player] = GetPlayer(player) + 1;
        }

        private int GetPlayer(string player)
        {
            if (!counter.ContainsKey(player))
                counter[player] = 0;

            return counter[player];
        }
    }
}