using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.GameEvents;
using System;

namespace dk.itu.game.msc.cgdl
{
    public class GDLFactory
    {
        private readonly EventLoggerFactory factory;
        private readonly Interpolator interpolator;

        public GDLFactory(EventLoggerFactory factory, Interpolator interpolator)
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
    }
}
