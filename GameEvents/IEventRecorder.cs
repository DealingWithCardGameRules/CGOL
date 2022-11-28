using dk.itu.game.msc.cgol.Distribution;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.GameEvents
{
    public interface IEventRecorder : IEventDispatcher
    {
        IEnumerable<IEvent> RecordedEvents { get; }

        Task Replay(IEnumerable<IEvent> events);
    }
}