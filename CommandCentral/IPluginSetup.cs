namespace dk.itu.game.msc.cgdl.CommandCentral
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