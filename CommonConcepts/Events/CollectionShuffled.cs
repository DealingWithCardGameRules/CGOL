using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Events
{
    public class CollectionShuffled : IEvent
    {
        public int Version => 1;

        public DateTime EventTime { get; }

        public Guid ProcessId { get; }
        public string Collection { get; }
        public int Seed { get; }

        public CollectionShuffled(DateTime eventTime, Guid processId, string collection, int seed)
        {
            EventTime = eventTime;
            ProcessId = processId;
            Collection = collection;
            Seed = seed;
        }
    }
}
