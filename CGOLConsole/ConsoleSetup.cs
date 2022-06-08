using CGOLConsole.Handlers;
using dk.itu.game.msc.cgol.Distribution;

namespace CGOLConsole
{
    public class ConsoleSetup : IPluginSetup
    {
        public void Setup(IPluginContext context)
        {
            context.Interpreter.AddConcept(new LoadCardHandler(context.Dispatcher));
        }
    }
}
