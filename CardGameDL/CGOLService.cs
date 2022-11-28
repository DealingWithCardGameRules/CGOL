using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.GameEvents;
using dk.itu.game.msc.cgol.Parser.Messages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol
{
    public class CGOLService
    {
        private readonly IDispatcher dispatcher;
        private readonly IPluginContext pluginContext;
        private readonly IEventRecorder eventRecorder;

        public CGOLService(IDispatcher dispatcher, IPluginContext pluginContext, IEventRecorder eventRecorder)
        {
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
            this.pluginContext = pluginContext ?? throw new System.ArgumentNullException(nameof(pluginContext));
            this.eventRecorder = eventRecorder ?? throw new System.ArgumentNullException(nameof(eventRecorder));
        }

        public async Task Dispatch(ICommand command)
        {
            dispatcher.Dispatch(command);
        }

        public async Task<T> Dispatch<T>(IQuery<T> query)
        {
            return await dispatcher.Dispatch(query);
        }

        public void Parse(string cgol)
        {
            Dispatch(new LoadCGOL(cgol));
        }

        public void LoadConcepts(IPluginSetup setup)
        {
            setup.Setup(pluginContext);
        }

        public void Replay(IEnumerable<IEvent> events)
        {
            eventRecorder.Replay(events);
        }

        public IEnumerable<IEvent> SessionEvents => eventRecorder.RecordedEvents;
    }
}