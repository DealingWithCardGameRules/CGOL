using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.Handlers;

namespace dk.itu.game.msc.cgol
{
    public class CGOLSetup : IPluginSetup
    {
        public void Setup(IPluginContext context)
        {
            context.Interpreter.AddConcept(new LoadBehaviorHandler(context));
        }
    }
}
