using System;

namespace dk.itu.game.msc.cgol.Distribution
{
    public interface ITimeProvider
    {
        DateTime Now { get; }
    }
}
