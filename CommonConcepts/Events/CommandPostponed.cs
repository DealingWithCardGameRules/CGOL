using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Events
{
    public class CommandPostponed : IEvent
    {
        public int Version => 1;

        public DateTime EventTime { get; }

        public Guid ProcessId { get; }
        public ICommand Command { get; }
        public string? Label { get; }

        public CommandPostponed(DateTime eventTime, Guid processId, ICommand command, string? label = null)
        {
            EventTime = eventTime;
            ProcessId = processId;
            Command = command;
            Label = label;
        }
    }
}
