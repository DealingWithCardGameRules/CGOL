using dk.itu.game.msc.cgol.Distribution;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgol.GameEvents
{
    internal class MemoryEventLogger : IEventLogger
    {
        readonly List<IEvent> log;

        public MemoryEventLogger()
        {
            log = new List<IEvent>();
        }

        public IEnumerable<IEvent> EventLog => log;

        public void AppendLog(IEvent @event)
        {
            log.Add(@event);
        }
    }
}
