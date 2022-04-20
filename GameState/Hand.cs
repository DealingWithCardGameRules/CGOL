using dk.itu.game.msc.cgdl.CommonConcepts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgdl.GameState
{
    internal class Hand : TagHandler, ICardCollection
    {
        public string Name { get; }

        public int? OwnerIndex { get; set; }

        Dictionary<Guid, ICard> cards;
        public Hand(string name) : base("hand")
        {
            Name = name;
            cards = new Dictionary<Guid, ICard>();
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

        public IEnumerable<ICard> GetRevieledCards(IEnumerable<int> playerIndices)
        {
            if (!OwnerIndex.HasValue || playerIndices.Contains(OwnerIndex.Value))
                return cards.Values;
            return new ICard[0];
        }

        public bool HasCard(Guid cardId)
        {
            return cards.ContainsKey(cardId);
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
    }
}
