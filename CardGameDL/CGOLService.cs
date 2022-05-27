using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.Parser.Messages;

namespace dk.itu.game.msc.cgol
{
    public class CGOLService
    {
        private readonly IDispatcher dispatcher;
        private readonly IPluginContext pluginContext;

        public CGOLService(IDispatcher dispatcher, IPluginContext pluginContext)
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

        public void Parse(string cgol)
        {
            Dispatch(new LoadCGOL(cgol));
        }

        public void LoadConcepts(IPluginSetup setup)
        {
            setup.Setup(pluginContext);
        }

    }
}