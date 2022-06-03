using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.GameEvents;
using System;

namespace dk.itu.game.msc.cgol
{
    public class DispatcherFactory
    {
        private readonly EventLogFactory factory;
        private readonly IInterpreter interpreter;

        public DispatcherFactory(EventLogFactory factory, IInterpreter interpreter)
        {
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
            this.interpreter = interpreter ?? throw new ArgumentNullException(nameof(interpreter));
        }

        public IDispatcher Create(string path, string fileName)
        {
            var file = factory.AbsoluteFile(path, fileName);
            factory.ResetFile(file);
            var logWriter = factory.CreateFileLogger(file);
            var eventDispatcher = new EventLogDecorator(new EventDispatcher(interpreter), logWriter);
            return new MessageDispatcher(interpreter, eventDispatcher);
        }

        public IDispatcher Create()
        {
            var eventDispatcher = new EventLogDecorator(new EventDispatcher(interpreter), factory.CreateMemoryLogger());
            return new MessageDispatcher(interpreter, eventDispatcher);
        }
    }
}
