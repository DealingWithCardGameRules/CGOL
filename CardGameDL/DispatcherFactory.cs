using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol
{
    public class DispatcherFactory
    {
        private readonly IEventDispatcher eventDispathcer;
        private readonly IInterpreter interpreter;

        public DispatcherFactory(IEventDispatcher eventDispathcer, IInterpreter interpreter)
        {
            this.eventDispathcer = eventDispathcer ?? throw new ArgumentNullException(nameof(eventDispathcer));
            this.interpreter = interpreter ?? throw new ArgumentNullException(nameof(interpreter));
        }

        public IDispatcher Create()
        {
            return new MessageDispatcher(interpreter, eventDispathcer);
        }
    }
}
