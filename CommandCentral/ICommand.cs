using System;

namespace dk.itu.game.msc.cgdl.Distribution
{
    public interface ICommand
    {
        Guid ProcessId { get; }
        Guid Instance { get; }
    }
}
