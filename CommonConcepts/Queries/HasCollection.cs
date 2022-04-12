using dk.itu.game.msc.cgdl.CommandCentral;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Queries
{
    public class HasCollection : IQuery<bool>
    {
        public string Name { get; }

        public HasCollection(string name)
        {
            Name = name;
        }
    }
}
