using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts
{
    public interface ICard : ITagable
    {
        Guid Instance { get; }
        int? OwnerIndex { get; set; }
        string Template { get; }
    }
}
