﻿using dk.itu.game.msc.cgdl.CommonConcepts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgdl.GameState
{
    internal class CardZone : TagHandler, ICardCollection
    {
        readonly Dictionary<Guid, ICard> cards;

        public string Name { get; }

        public int? OwnerIndex { get; set; }

        public CardZone(string name) : base("community")
        {
            cards = new Dictionary<Guid, ICard>();
            Name = name;
        }

        public void AddCard(ICard card)
        {
            cards.Add(card.Instance, card);
        }

        public int Count()
        {
            return cards.Count();
        }

        public ICard? Get(Guid cardId)
        {
            if (cards.ContainsKey(cardId))
                return cards[cardId];
            return null;
        }

        public ICard? GetCard()
        {
            return cards.Values.FirstOrDefault();
        }

        public IEnumerable<ICard> GetRevieledCards(IEnumerable<int> playerIndices)
        {
            return cards.Values;
        }

        public bool HasCard(Guid cardId)
        {
            return cards.ContainsKey(cardId);
        }

        public void RemoveCard(Guid cardId)
        {
            cards.Remove(cardId);
        }

        public bool TrySetCardOwner(Guid cardId, int playerIndex)
        {
            if (!cards.ContainsKey(cardId))
            {
                cards[cardId].OwnerIndex = playerIndex;
                return true;
            }
            return false;
        }
    }
}