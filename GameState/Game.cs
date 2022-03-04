using dk.itu.game.msc.cgdl.CommonConcepts;
using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.GameState
{
    public class Game
    {
        readonly Dictionary<string, ICardCollection> collections;

        public Game()
        {
            collections = new Dictionary<string, ICardCollection>();
        }

        internal void AddStack(CardStack stack)
        {
            collections.Add(stack.Name, stack);
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

        internal void AddHand(Hand hand)
        {
            collections.Add(hand.Name, hand);
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
