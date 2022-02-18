using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.CommonConcepts
{
    public interface ICardStack
    {
        Guid Instance { get; }
        IEnumerable<ICard> Cards { get; }
    }
}
