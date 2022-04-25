using dk.itu.game.msc.cgdl.CommandCentral;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Events
{
    public class TagsAddedToCollection : IEvent
    {
        public int Version => 1;

        public DateTime EventTime { get; }

        public Guid ProcessId { get; }
        public string Collection { get; }
        public string[] Tags { get; }

        public TagsAddedToCollection(DateTime eventTime, Guid processId, string collection, IEnumerable<string> tags)
        {
            EventTime = eventTime;
            ProcessId = processId;
            Collection = collection ?? throw new ArgumentNullException(nameof(collection));
            Tags = tags.ToArray();
        }
    }
}
