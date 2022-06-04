using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.GameEvents;

namespace dk.itu.game.msc.cgol
{
    internal class EventRecorderFactory
    {
        private readonly EventLogFactory factory;
        private readonly IInterpreter interpreter;

        public EventRecorderFactory(EventLogFactory factory, IInterpreter interpreter)
        {
            this.factory = factory ?? throw new System.ArgumentNullException(nameof(factory));
            this.interpreter = interpreter ?? throw new System.ArgumentNullException(nameof(interpreter));
        }

        public IEventRecorder Create()
        {
            return new EventRecorder(new EventDispatcher(interpreter), factory.CreateMemoryLogger());
        }
    }
}
