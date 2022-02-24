using dk.itu.game.msc.cgdl.CommonConcepts;
using System;

namespace dk.itu.game.msc.cgdl.GameState
{
    internal interface ICardCollection
    {
        Guid Instance { get; }
        void AddCard(ICard card);
        void RemoveCard(Guid cardId);
        ICard? GetCard();
        ICard? Get(Guid cardId);
        int Count();
    }
}
