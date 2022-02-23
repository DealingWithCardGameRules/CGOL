using dk.itu.game.msc.cgdl.CommonConcepts;
using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.GameState
{
    internal class CardStack : ICardStack
    {
        public Guid Instance { get; private set; }

        List<ICard> cards;

        public IEnumerable<ICard> Cards => cards;

        public CardStack(Guid id)
        {
            Instance = id;
            cards = new List<ICard>();
        }

        public void AddCard(ICard card)
        {
            cards.Add(card);
        }
    }
}
