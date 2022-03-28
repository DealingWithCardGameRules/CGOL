using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.CommonConcepts
{
    public interface ICard : ITagable
    {
        Guid Instance { get; }
        string Template { get; }
    }
}
