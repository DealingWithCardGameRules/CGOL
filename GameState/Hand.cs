using dk.itu.game.msc.cgdl.CommonConcepts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgdl.GameState
{
    internal class Hand : ICardCollection
    {
        public string Name { get; }

        public IEnumerable<string> Tags => tags;

        readonly List<string> tags;
        readonly Dictionary<Guid, ICard> cards;
        public Hand(string name)
        {
            Name = name;
            cards = new Dictionary<Guid, ICard>();
            tags = new List<string>
            {
                "hand"
            };
        }

        public void AddCard(ICard card)
        {
            cards[card.Instance] = card;
        }

        public void RemoveCard(Guid cardId)
        {
            if (cards.ContainsKey(cardId))
                cards.Remove(cardId);
        }

        public ICard? GetCard()
        {
            if (cards.Count > 0)
                return cards.Last().Value;
            return null;
        }

        public ICard? Get(Guid cardId)
        {
            if (cards.ContainsKey(cardId))
                return cards[cardId];
            return null;
        }

        public int Count()
        {
            return cards.Count;
        }

        public IEnumerable<ICard> GetRevieledCards()
        {
            return cards.Values;
        }   
    }
}
