using System;

namespace dk.itu.game.msc.cgdl.CommandCentral
{
    public interface IEvent
    {
        DateTime EventTime { get; }
        int Version { get; }
        Guid ProcessId { get; }
    }
}
