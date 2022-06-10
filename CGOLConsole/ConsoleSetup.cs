using CGOLConsole.Handlers;
using dk.itu.game.msc.cgol.Distribution;

namespace CGOLConsole
{
    public class ConsoleSetup : IPluginSetup
    {
        internal GameStats Stats { get; set; }

        public void Setup(IPluginContext context)
        {
            Stats = new GameStats(context.Dispatcher);
            context.Interpreter.AddConcept(new GameWonObserver(Stats));
            context.Interpreter.AddConcept(new LoadCardHandler(context.Dispatcher));
            context.Interpreter.AddConcept(new PickACardHandler());
        }
    }
}
