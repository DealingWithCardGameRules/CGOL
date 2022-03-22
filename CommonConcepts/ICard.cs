using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts
{
    public interface ICard
    {
        Guid Instance { get; }
        string Template { get; }
    }
}
