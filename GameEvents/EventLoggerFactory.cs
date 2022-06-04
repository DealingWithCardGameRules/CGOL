using System.IO;

namespace dk.itu.game.msc.cgol.GameEvents
{
    public class EventLogFactory
    {

        public IEventLogger CreateMemoryLogger()
        {
            return Wrap(new MemoryEventLogger());
        }

        private IEventLogger Wrap(IEventLogger eventLogger)
        {
            return new AppendOnlyDecorator(eventLogger);
        }
    }
}
