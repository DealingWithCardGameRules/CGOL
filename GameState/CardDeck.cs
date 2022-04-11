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

        public int? OwnerIndex { get; set; }

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

        public bool HasCard(Guid cardId)
        {
            for (int i = 0; i < cards.Count; i++)
            {
                if (cards[i].Instance == cardId)
                {
                    return true;
                }
            }
            return false;
        }

        public bool TrySetCardOwner(Guid cardId, int playerIndex)
        {
            foreach (var card in cards)
            {
                if (card.Instance == cardId)
                {
                    card.OwnerIndex = playerIndex;
                    return true;
                }
            }
            return false;
        }
    }
}
