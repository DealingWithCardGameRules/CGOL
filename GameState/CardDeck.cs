using dk.itu.game.msc.cgdl.CommonConcepts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgdl.GameState
{
    internal class CardDeck : ICardCollection
    {
        public string Name { get; }
        public IEnumerable<string> Tags => tags;

        readonly List<string> tags;
        readonly List<ICard> cards;

        public CardDeck(string name)
        {
            Name = name;
            cards = new List<ICard>();
            tags = new List<string>
            {
                "deck"
            };
        }

        public void AddCard(ICard card)
        {
            cards.Add(card);
        }

        public void RemoveCard(Guid cardId)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                if (cards[i].Instance == cardId)
                {
                    cards.RemoveAt(i);
                    return;
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

        public IEnumerable<ICard> GetRevieledCards()
        {
            yield break; // Never reviel
        }
    }
}
