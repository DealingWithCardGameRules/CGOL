using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl
{
    internal class UtcTime : ITimeProvider
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
