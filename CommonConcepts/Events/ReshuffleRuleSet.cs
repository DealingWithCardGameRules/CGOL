using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.CommonConcepts.Events
{
    public class ReshuffleRuleSet : IEvent
    {
        public int Version => 1;

        public DateTime EventTime { get; }

        public Guid ProcessId { get; }
        public string From { get; }
        public string To { get; }
        
        [Concept(Description = "A reshuffle rule was set up. The from collection will be shuffled into the to collection if the to collection runs out of cards.")]
        public ReshuffleRuleSet(DateTime eventTime, Guid processId, string from, string to)
        {
            EventTime = eventTime;
            ProcessId = processId;
            From = from;
            To = to;
        }
    }
}
