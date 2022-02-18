using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts
{
    public interface ICard
    {
        Guid Template { get; }
        Guid Instance { get; }
        string Name { get; }
    }
}
