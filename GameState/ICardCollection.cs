﻿using dk.itu.game.msc.cgol.CommonConcepts;
using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgol.GameState
{
    internal interface ICardCollection : ITagable
    {
        string Name { get; }
        int? OwnerIndex { get; set; } // The player index of the owner
        void AddCard(ICard card);
        void RemoveCard(Guid cardId);
        ICard? GetCard();
        ICard? Get(Guid cardId);
        int Count();
        IEnumerable<ICard> GetRevieledCards(IEnumerable<int> playerIndices);
        bool HasCard(Guid cardId);
        bool TrySetCardOwner(Guid cardId, int playerIndex);
        void Shuffle(int seed);
        IEnumerable<ICard> GetCards(IEnumerable<string>? tags);
        ICard? GetRandomCard();
    }
}
