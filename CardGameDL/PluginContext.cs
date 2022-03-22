using dk.itu.game.msc.cgdl.CommandCentral;

namespace dk.itu.game.msc.cgdl
{
    public class PluginContext : IPluginContext
    {
        public IInterpolator Interpolator { get; }
        public ITimeProvider TimeProvider { get; }
        public IDispatcher Dispatcher { get; }

        public PluginContext(IInterpolator interpolator, ITimeProvider timeProvider, IDispatcher dispatcher)
        {
            Interpolator = interpolator ?? throw new System.ArgumentNullException(nameof(interpolator));
            TimeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
            Dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }
    }
}
