using dk.itu.game.msc.cgol.Distribution;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgol.GameEvents
{
    public interface IEventRecorder : IEventDispatcher
    {
        IEnumerable<IEvent> RecordedEvents { get; }

        void Replay(IEnumerable<IEvent> events);
    }
}