using dk.itu.game.msc.cgol.Distribution;

namespace CardGameWebApp.Server
{
    public class ConceptHandlerSetup : IPluginSetup
    {
        private readonly StorageService storage;
        private readonly WebContext webcontext;

        public ConceptHandlerSetup(StorageService storage, WebContext webcontext)
        {
            this.storage = storage;
            this.webcontext = webcontext;
        }

        public void Setup(IPluginContext context)
        {
            context.Interpreter.AddConcept(new LoadCardHandler(context.Dispatcher, storage, webcontext));
        }
    }
}
