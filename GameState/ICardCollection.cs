using dk.itu.game.msc.cgdl.CommonConcepts;
using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.GameState
{
    internal interface ICardCollection
    {
        string Name { get; }
        IEnumerable<string> Tags { get; }

        void AddCard(ICard card);
        void RemoveCard(Guid cardId);
        ICard? GetCard();
        ICard? Get(Guid cardId);
        int Count();
        IEnumerable<ICard> GetRevieledCards();
    }
}
