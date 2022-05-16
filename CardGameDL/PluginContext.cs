using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl
{
    public class PluginContext : IPluginContext
    {
        public IInterpreter Interpolator { get; }
        public ITimeProvider TimeProvider { get; }
        public IDispatcher Dispatcher { get; }

        public PluginContext(IInterpreter interpolator, ITimeProvider timeProvider, IDispatcher dispatcher)
        {
            Interpolator = interpolator ?? throw new System.ArgumentNullException(nameof(interpolator));
            TimeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
            Dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }
    }
}
