using System;

namespace dk.itu.game.msc.cgdl.Distribution
{
    public interface IEvent
    {
        int Version { get; }
        DateTime EventTime { get; }
        Guid ProcessId { get; }
    }
}
