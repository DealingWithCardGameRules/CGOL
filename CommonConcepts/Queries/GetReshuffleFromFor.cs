using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.CommonConcepts.Queries
{
    public class GetReshuffleFromFor : IQuery<string?>
    {
        public string Destination { get; }

        [Concept(Description = "Try to find a reshuffle rule where the specified collection is the destination. Returns the name of the collection to shuffle from.")]
        public GetReshuffleFromFor(string destination)
        {
            Destination = destination;
        }
    }
}
