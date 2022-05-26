namespace dk.itu.game.msc.cgol.Distribution
{
    public interface IPluginSetup
    {
        void Setup(IPluginContext context);
    }

    public interface IPluginContext
    {
        IInterpreter Interpreter { get; }
        ITimeProvider TimeProvider { get; }
        IDispatcher Dispatcher { get; }
    }
}