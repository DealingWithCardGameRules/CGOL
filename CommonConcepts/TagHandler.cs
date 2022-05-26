using System.Collections.Generic;

namespace dk.itu.game.msc.cgol.CommonConcepts
{
    public abstract class TagHandler : ITagable
    {
        private readonly List<string> tags;
        public IEnumerable<string> Tags => tags;

        public TagHandler()
        {
            tags = new List<string>();
        }

        public TagHandler(IEnumerable<string> initialTags)
        {
            tags = new List<string>(initialTags);
        }

        public TagHandler(params string[] initialTags)
        {
            tags = new List<string>(initialTags);
        }

        public void AddTag(string tag)
        {
            tags.Add(tag);
        }

        public void RemoveTag(string tag)
        {
            tags.Remove(tag);
        }
    }
}
