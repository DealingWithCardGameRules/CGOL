using dk.itu.game.msc.cgol.CommonConcepts;
using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.GameState;
using dk.itu.game.msc.cgol.Parser;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace dk.itu.game.msc.cgol
{
    public class CGOLServiceFactory
    {
        readonly IServiceProvider serviceProvider;
        public CGOLServiceFactory()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddCGOLBasics();
            serviceCollection.AddCGOLParser();
            serviceProvider = serviceCollection.BuildServiceProvider();
        }

        public CGOLService CreateEmpty()
        {
            var recorder = serviceProvider.GetRequiredService<EventRecorderFactory>().Create();
            var interpreter = serviceProvider.GetRequiredService<IInterpreter>();
            var dispatcher = new MessageDispatcher(interpreter, recorder);
            var timeProvider = serviceProvider.GetRequiredService<ITimeProvider>();
            var context = new PluginContext(interpreter, timeProvider, dispatcher);
            return new CGOLService(dispatcher, context, recorder);
        }

        public CGOLService CreateBasic()
        {
            var service = CreateEmpty();
            service.LoadConcepts(new CommonConceptsSetup());
            service.LoadConcepts(serviceProvider.GetRequiredService<LanguageParserSetup>());
            service.LoadConcepts(new GameStateSetup());
            service.LoadConcepts(new CGOLSetup());
            return service;
        }

        public IInterpreter GetInterpreter()
        {
            return serviceProvider.GetRequiredService<IInterpreter>();
        }
    }
}
