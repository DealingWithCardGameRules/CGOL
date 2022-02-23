using dk.itu.game.msc.cgdl.CommandCentral;
using System;

namespace dk.itu.game.msc.cgdl
{
    internal class UtcTime : ITimeProvider
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
