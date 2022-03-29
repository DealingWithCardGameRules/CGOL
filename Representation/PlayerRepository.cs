using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.Representation
{
    public class PlayerRepository
    {
        private readonly Dictionary<int, string> players;

        public PlayerRepository()
        {
            players = new Dictionary<int, string>();
        }

        public void AddPlayer(int index, string playerId)
        {
            players[index] = playerId;
        }

        public string? GetPlayer(int index)
        {
            if (players.ContainsKey(index))
                return players[index];
            return null;
        }

        public void RemovePlayer(int playerIndex)
        {
            players.Remove(playerIndex);
        }
    }
}
