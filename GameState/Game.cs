using dk.itu.game.msc.cgdl.CommonConcepts;
using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.GameState
{
    public class Game
    {
        readonly Dictionary<Guid, ICardCollection> collections;

        public Game()
        {
            collections = new Dictionary<Guid, ICardCollection>();
        }

        internal void AddStack(CardStack stack)
        {
            collections.Add(stack.Instance, stack);
        }

        internal int CollectionSize(Guid collectionId)
        {
            return collections[collectionId].Count();
        }

        internal ICard? GetCard(Guid collectionId)
        {
            return collections[collectionId].GetCard();
        }

        internal void AddHand(Hand hand)
        {
            collections.Add(hand.Instance, hand);
        }

        internal void AddCard(Guid collectionId, ICard card)
        {
            collections[collectionId].AddCard(card);
        }

        internal void RemoveCard(Guid collectionId, Guid cardId)
        {
            collections[collectionId].RemoveCard(cardId);
        }
    }
}
