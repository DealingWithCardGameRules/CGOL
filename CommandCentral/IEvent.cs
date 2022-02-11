using System;

namespace dk.itu.game.msc.cgdl.CommandCentral
{
    public interface IEvent
    {
        DateTime EventDate { get; }
        int Version { get; }
        Guid ProcessId { get; }
    }
}
