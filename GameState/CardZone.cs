using dk.itu.game.msc.cgol.CommonConcepts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgol.GameState
{
    internal class CardZone : TagHandler, ICardCollection
    {
        Dictionary<Guid, ICard> cards;

        public string Name { get; }

        public int? OwnerIndex { get; set; }

        public CardZone(string name)
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
            if (cards.ContainsKey(cardId))
            {
                cards[cardId].OwnerIndex = playerIndex;
                return true;
            }
            return false;
        }

        public void Shuffle(int seed)
        {
            cards = new Shuffler(seed).Shuffle(cards);
        }

        public IEnumerable<ICard> GetCards(IEnumerable<string> tags)
        {
            foreach (var card in cards.Values)
            {
                if (tags == null || card.Tags.Intersect(tags).Count() == tags.Count())
                    yield return card;
            }
        }

        public IEnumerable<ICard> GetCards()
        {
            return cards.Values;
        }

        public ICard? GetRandomCard()
        {
            return cards.Values.RandomOrDefault();
        }
    }
}
