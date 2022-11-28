using Agents;
using dk.itu.game.msc.cgol.CommonConcepts;
using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.GameState;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol
{
    public class AIAgentFactory
    {
        readonly IServiceProvider serviceProvider;
        public AIAgentFactory()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddCGOLBasics();
            serviceCollection.AddCGOLParser();
            serviceProvider = serviceCollection.BuildServiceProvider();
        }
        public ICGOLAgent CreateRandom()
        {
            var recorder = serviceProvider.GetRequiredService<EventRecorderFactory>().Create();
            var interpreter = serviceProvider.GetRequiredService<IInterpreter>();
            var dispatcher = new MessageDispatcher(interpreter, new DummyEventDisPatcher());
            var timeProvider = serviceProvider.GetRequiredService<ITimeProvider>();
            var context = new PluginContext(interpreter, timeProvider, dispatcher);
            new CommonConceptsSetup().Setup(context);
            new GameStateSetup().Setup(context);
            return new RandomAgent(recorder, dispatcher);
        }

        class DummyEventDisPatcher : IEventDispatcher
        {
            public async Task Dispatch(IEvent @event)
            {
                
            }
        }
    }
}
