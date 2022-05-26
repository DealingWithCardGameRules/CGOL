using System;

namespace dk.itu.game.msc.cgol.Distribution
{
    public interface IEvent
    {
        int Version { get; }
        DateTime EventTime { get; }
        Guid ProcessId { get; }
    }
}
