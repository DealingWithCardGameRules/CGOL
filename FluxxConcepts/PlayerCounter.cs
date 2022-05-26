using System.Collections.Generic;

namespace dk.itu.game.msc.cgol.FluxxConcepts
{
    public class PlayerCounter
    {
        private Dictionary<int, int> counter;
        private int limit = 0;

        public PlayerCounter()
        {
            counter = new Dictionary<int, int>();
        }

        internal void SetLimit(int limit)
        {
            this.limit = limit;
        }

        internal bool ReachedFor(int playerIndex)
        {
            return limit != 0 && GetPlayer(playerIndex) >= limit;
        }

        internal int GetLimit(int? playerIndex)
        {
            return limit; // Currently the same for all players
        }

        internal void ResetPlayer(int playerIndex)
        {
            counter[playerIndex] = 0;
        }

        internal void Aggregate(int playerIndex)
        {
            counter[playerIndex] = GetPlayer(playerIndex) + 1;
        }

        private int GetPlayer(int playerIndex)
        {
            if (!counter.ContainsKey(playerIndex))
                counter[playerIndex] = 0;

            return counter[playerIndex];
        }
    }
}