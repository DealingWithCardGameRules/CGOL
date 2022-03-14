using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts
{
    public interface ICard
    {
        string Name { get; }
        Guid Instance { get; }
        string Illustration { get; }
        string Description { get; }
        string? Template { get; }
    }
}
