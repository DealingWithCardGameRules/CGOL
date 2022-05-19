using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
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
