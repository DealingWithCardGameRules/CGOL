using dk.itu.game.msc.cgol;
using dk.itu.game.msc.cgol.CommonConcepts;
using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.GameState;
using dk.itu.game.msc.cgol.Parser;
using Microsoft.Extensions.DependencyInjection;

namespace CGOLConsole
{
    internal class ConsoleCGOLFactory
    {
        readonly IServiceProvider serviceProvider;
        public ConsoleCGOLFactory()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddCGOLBasics();
            serviceCollection.AddCGOLParser();
            serviceProvider = serviceCollection.BuildServiceProvider();
        }
        public CGOLService Create()
        {
            var recorder = serviceProvider.GetRequiredService<EventRecorderFactory>().Create();
            var interpreter = serviceProvider.GetRequiredService<IInterpreter>();
            var consoleEvents = new ConsoleEventDispatchDecorator(recorder, new ConsoleWriter());
            var dispatcher = new MessageDispatcher(interpreter, consoleEvents);
            var timeProvider = serviceProvider.GetRequiredService<ITimeProvider>();
            var context = new PluginContext(interpreter, timeProvider, dispatcher);
            var service = new CGOLService(dispatcher, context, recorder);
            service.LoadConcepts(new CommonConceptsSetup());
            service.LoadConcepts(serviceProvider.GetRequiredService<LanguageParserSetup>());
            service.LoadConcepts(new GameStateSetup());
            service.LoadConcepts(new CGOLSetup());
            return service;
        }
    }
}
