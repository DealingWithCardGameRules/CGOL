using System;

namespace dk.itu.game.msc.cgol.Distribution
{
    public interface ICommand
    {
        Guid ProcessId { get; }
        Guid Instance { get; }
    }
}
