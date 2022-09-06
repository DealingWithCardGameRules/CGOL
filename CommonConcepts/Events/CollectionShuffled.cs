using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.CommonConcepts.Events
{
    public class CollectionShuffled : IEvent
    {
        public int Version => 1;

        public DateTime EventTime { get; }

        public Guid ProcessId { get; }
        public string Collection { get; }
        public int Seed { get; }

        [Concept(Description = "The card collection was shuffled using the seed. This ensures the same random order if the event is replayed.")]
        public CollectionShuffled(DateTime eventTime, Guid processId, string collection, int seed)
        {
            EventTime = eventTime;
            ProcessId = processId;
            Collection = collection;
            Seed = seed;
        }

        public override string ToString()
        {
            return $"The collection \"{Collection}\" was shuffled ({Seed}).";
        }
    }
}
