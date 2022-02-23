using System;

namespace dk.itu.game.msc.cgdl.CommandCentral
{
    public interface ITimeProvider
    {
        DateTime Now { get; }
    }
}
