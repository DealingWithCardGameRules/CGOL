using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.GameEvents;
using System;

namespace dk.itu.game.msc.cgol
{
    public class DispatcherFactory
    {
        private readonly EventLoggerFactory factory;
        private readonly IInterpreter interpolator;

        public DispatcherFactory(EventLoggerFactory factory, IInterpreter interpolator)
        {
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
            this.interpolator = interpolator ?? throw new ArgumentNullException(nameof(interpolator));
        }

        public IDispatcher Create(string path, string fileName)
        {
            var logWriter = factory.NewLog(path, fileName);
            var eventDispatcher = new EventLogDecorator(new EventDispatcher(interpolator), logWriter);
            return new MessageDispatcher(interpolator, eventDispatcher);
        }

        public IDispatcher Create()
        {
            return new MessageDispatcher(interpolator, new EventDispatcher(interpolator));
        }
    }
}
