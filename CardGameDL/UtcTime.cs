using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol
{
    internal class UtcTime : ITimeProvider
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
