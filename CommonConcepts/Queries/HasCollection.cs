using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.CommonConcepts.Queries
{
    public class HasCollection : IQuery<bool>
    {
        public string Name { get; }

        [Concept(Description = "Check if a specific collection exists.")]
        public HasCollection(string name)
        {
            Name = name;
        }
    }
}
