using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgol.CommonConcepts.Events
{
    public class TagsAddedToTemplate : IEvent
    {
        public int Version => 1;

        public DateTime EventTime { get; }

        public Guid ProcessId { get; }
        public string Template { get; }
        public string[] Tags { get; }

        [Concept(Description = "Tags were added to the card template.")]
        public TagsAddedToTemplate(DateTime eventTime, Guid processId, string template, IEnumerable<string> tags)
        {
            EventTime = eventTime;
            ProcessId = processId;
            Template = template;
            Tags = tags.ToArray();
        }
    }
}
