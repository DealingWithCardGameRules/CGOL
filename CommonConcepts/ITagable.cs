using System.Collections.Generic;

namespace dk.itu.game.msc.cgol.CommonConcepts
{
    public interface ITagable
    {
        IEnumerable<string> Tags { get; }
        void AddTag(string tag);
        void RemoveTag(string tag);
    }
}
