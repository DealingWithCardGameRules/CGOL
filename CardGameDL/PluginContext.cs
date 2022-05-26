using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol
{
    public class PluginContext : IPluginContext
    {
        public IInterpreter Interpreter { get; }
        public ITimeProvider TimeProvider { get; }
        public IDispatcher Dispatcher { get; }

        public PluginContext(IInterpreter interpolator, ITimeProvider timeProvider, IDispatcher dispatcher)
        {
            Interpreter = interpolator ?? throw new System.ArgumentNullException(nameof(interpolator));
            TimeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
            Dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }
    }
}
