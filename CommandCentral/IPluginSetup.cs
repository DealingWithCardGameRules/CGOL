namespace dk.itu.game.msc.cgdl.Distribution
{
    public interface IPluginSetup
    {
        void Setup(IPluginContext context);
    }

    public interface IPluginContext
    {
        IInterpreter Interpolator { get; }
        ITimeProvider TimeProvider { get; }
        IDispatcher Dispatcher { get; }
    }
}