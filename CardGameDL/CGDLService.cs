using dk.itu.game.msc.cgdl.Distribution;
using dk.itu.game.msc.cgdl.LanguageParser.Messages;

namespace dk.itu.game.msc.cgdl
{
    public class CGDLService
    {
        private readonly IDispatcher dispatcher;
        private readonly IPluginContext pluginContext;

        public CGDLService(IDispatcher dispatcher, IPluginContext pluginContext)
        {
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
            this.pluginContext = pluginContext ?? throw new System.ArgumentNullException(nameof(pluginContext));
        }

        public void Dispatch(ICommand command)
        {
            dispatcher.Dispatch(command);
        }

        public T Dispatch<T>(IQuery<T> query)
        {
            return dispatcher.Dispatch<T>(query);
        }

        public void Parse(string cgdl)
        {
            dispatcher.Dispatch(new LoadCGDL(cgdl));    
        }

        public void LoadConcepts(IPluginSetup setup)
        {
            setup.Setup(pluginContext);
        }

    }
}