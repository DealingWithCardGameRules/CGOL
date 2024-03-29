﻿using dk.itu.game.msc.cgol.CommonConcepts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgol.GameState
{
    internal class Game 
    {
        internal string? CurrentState { get; set; } = null;

        private readonly Dictionary<string, ICardCollection> collections;
        private readonly Dictionary<int, IPlayer> players;
        private int currentPlayer = 0;

        public Game()
        {
            collections = new Dictionary<string, ICardCollection>();
            players = new Dictionary<int, IPlayer>();
        }

        internal ICard? GetRandomCard(string collection)
        {
            return collections[collection].GetRandomCard();
        }

        internal void AddTag(string collection, string tag)
        {
            collections[collection].AddTag(tag);
        }

        internal void RemoveCollection(string collection)
        {
            collections.Remove(collection);
        }

        internal void ShuffleCollection(string collection, int seed)
        {
            collections[collection].Shuffle(seed);
        }

        internal IEnumerable<ICard> GetCards(string collection, IEnumerable<string>? tags = null)
        {
            return collections[collection].GetCards(tags);
        }

        internal string? GetPlayerHand(int playerIndex)
        {
            return collections
                    .Where(c => c.Value.Tags.Contains("hand") && c.Value.OwnerIndex == playerIndex)
                    .Select(c => c.Key)
                    .FirstOrDefault();
        }

        internal bool HasCollection(string name)
        {
            return collections.ContainsKey(name);
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

        private IEnumerable<KeyValuePair<string, ICardCollection>> CollectionOf(int owner)
        {
            return collections.Where(c => c.Value.OwnerIndex.Equals(owner));
        }

        internal IEnumerable<string> CollectionNames(int? owner = null, IEnumerable<string>? tags = null)
        {
            var cols = owner.HasValue ? CollectionOf(owner.Value) : collections;
            if (tags != null)
                cols = cols.Where(p => p.Value.Tags.Count(t => tags.Contains(t)) == tags.Count());
            return cols.Select(c => c.Key);
        }

        internal void AddCollection(ICardCollection collection)
        {
            collections.Add(collection.Name, collection);
        }

        internal int CollectionSize(string collection)
        {
            return collections[collection].Count();
        }

        internal ICard? GetCard(string collection)
        {
            return collections[collection].GetCard();
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
