using dk.itu.game.msc.cgdl.CommonConcepts.Attributes;
using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Events
{
    public class CurrentPlayerSelected : IEvent
    {
        public int Version => 1;

        public DateTime EventTime { get; }

        public Guid ProcessId { get; }
        public int PlayerIndex { get; }

        [Concept(Description = "The current player was selected.")]
        public CurrentPlayerSelected(DateTime eventTime, Guid processId, int playerIndex)
        {
            EventTime = eventTime;
            ProcessId = processId;
            PlayerIndex = playerIndex;
        }
    }
}
