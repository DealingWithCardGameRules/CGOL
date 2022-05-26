using dk.itu.game.msc.cgol.CommonConcepts.Attributes;
using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.CommonConcepts.Events
{
    public class CommandPostponed : IEvent
    {
        public int Version => 1;

        public DateTime EventTime { get; }

        public Guid ProcessId { get; }
        public ICommand Command { get; }
        public string? Label { get; }

        [Concept(Description = "The command was postponed permanently as a player action.")]
        public CommandPostponed(DateTime eventTime, Guid processId, ICommand command, string? label = null)
        {
            EventTime = eventTime;
            ProcessId = processId;
            Command = command;
            Label = label;
        }
    }
}
