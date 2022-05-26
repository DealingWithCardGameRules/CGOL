using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgol.CommonConcepts.Events
{
    public class CGOLLoaded : IEvent
    {
        public int Version => 1;

        public DateTime EventTime { get; }

        public Guid ProcessId { get; }
        public ICommand[] Commands { get; }

        [Concept(Description = "These commands were loaded.")]
        public CGOLLoaded(DateTime eventTime, Guid processId, IEnumerable<ICommand> commands)
        {
            EventTime = eventTime;
            ProcessId = processId;
            Commands = commands.ToArray();
        }
    }
}
