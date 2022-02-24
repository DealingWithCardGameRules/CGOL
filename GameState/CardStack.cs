﻿using dk.itu.game.msc.cgdl.CommonConcepts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgdl.GameState
{
    internal class CardStack : ICardCollection
    {
        public Guid Instance { get; }
        List<ICard> cards;

        public CardStack(Guid id)
        {
            Instance = id;
            cards = new List<ICard>();
        }

        public void AddCard(ICard card)
        {
            cards.Add(card);
        }

        public void RemoveCard(Guid cardId)
        {
            foreach(var card in cards)
            {
                if (card.Instance == cardId)
                {
                    cards.Remove(card);
                }
            }
        }

        public ICard? GetCard()
        {
            return cards.Last();
        }

        public ICard? Get(Guid cardId)
        {
            return cards.FirstOrDefault(c => c.Instance == cardId);
        }

        public int Count()
        {
            return cards.Count();
        }
    }
}
