using System;

namespace dk.itu.game.msc.cgdl.CommandCentral
{
    public interface ICommand
    {
        Guid ProcessId { get; }
        Guid Instance { get; }
    }
}
