using System;

namespace dk.itu.game.msc.cgdl.Distribution
{
    public interface ITimeProvider
    {
        DateTime Now { get; }
    }
}
