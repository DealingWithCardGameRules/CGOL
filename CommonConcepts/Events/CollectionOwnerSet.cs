using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Events
{
    public class CollectionOwnerSet : IEvent
    {
        public int Version => 1;

        public DateTime EventTime { get; }

        public Guid ProcessId { get; }
        public int PlayerIndex { get; }
        public string Collection { get; set; }

        [Concept(Description = "The owner of the collection was set to the player.")]
        public CollectionOwnerSet(DateTime eventTime, Guid processId, string collection, int player)
        {
            EventTime = eventTime;
            ProcessId = processId;
            Collection = collection;
            PlayerIndex = player;
        }
    }
}
