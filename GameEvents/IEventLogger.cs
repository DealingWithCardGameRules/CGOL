using dk.itu.game.msc.cgol.Distribution;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgol.GameEvents
{
    public interface IEventLogger
    {
        void AppendLog(IEvent @event);
        IEnumerable<IEvent> EventLog { get; }
    }
}
