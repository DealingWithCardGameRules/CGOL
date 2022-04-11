using dk.itu.game.msc.cgdl.CommonConcepts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgdl.GameState
{
    public class Game
    {
        private readonly Dictionary<string, ICardCollection> collections;
        private readonly Dictionary<int, IPlayer> players;
        private int currentPlayer = 0;

        public Game()
        {
            collections = new Dictionary<string, ICardCollection>();
            players = new Dictionary<int, IPlayer>();
        }

        internal void SetCollectionOwner(string name, int playerIndex)
        {
            collections[name].OwnerIndex = playerIndex;
        }

        internal int? GetCollectionOwner(string collection)
        {
            if (collections.ContainsKey(collection))
                return collections[collection].OwnerIndex;
            return null;
        }

        internal void SetCardOwner(Guid cardId, int playerIndex)
        {
            foreach (var collection in collections)
            {
                if (collection.Value.TrySetCardOwner(cardId, playerIndex))
                    return;
            }
        }

        internal int CountPlayers()
        {
            return players.Count;
        }

        internal IPlayer? GetCurrentPlayer()
        {
            if (players.ContainsKey(currentPlayer))
                return players[currentPlayer];
            return null;
        }

        internal void SetCurrentPlayer(int index)
        {
            currentPlayer = index;
        }

        internal IEnumerable<ICard> GetRevieledCards(string collection, IEnumerable<int> playerIndices)
        {
            return collections[collection].GetRevieledCards(playerIndices);
        }

        internal void SetPlayer(IPlayer player)
        {
            players[player.Index] = player;
        }

        internal IEnumerable<string> CollectionNames() => collections.Keys;

        internal string? WhoHas(Guid cardId)
        {
            foreach (var collection in collections)
            {
                if (collection.Value.HasCard(cardId))
                    return collection.Key;
            }
            return null;
        }

        internal IEnumerable<string> GetTags(string collection)
        {
            return collections[collection].Tags;
        }

        internal IEnumerable<string> CollectionNames(IEnumerable<string> tags)
        {
            foreach (var collection in collections.Where(p => p.Value.Tags.Count(t => tags.Contains(t)) == tags.Count()))
            {
                yield return collection.Key;
            }
        }

        internal void AddCollection(ICardCollection collection)
        {
            collections.Add(collection.Name, collection);
        }

        internal int CollectionSize(string stack)
        {
            return collections[stack].Count();
        }

        internal ICard? GetCard(string stack)
        {
            return collections[stack].GetCard();
        }

        internal ICard? GetCard(string collection, Guid cardId)
        {
            return collections[collection].Get(cardId);
        }

        internal void AddCard(string collect, ICard card)
        {
            collections[collect].AddCard(card);
        }

        internal void RemoveCard(string collection, Guid cardId)
        {
            collections[collection].RemoveCard(cardId);
        }
    }
}
