using dk.itu.game.msc.cgol.CommonConcepts;
using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.GameState;
using dk.itu.game.msc.cgol.Handlers;
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
            serviceCollection.AddCGOLService();
            serviceProvider = serviceCollection.BuildServiceProvider();
        }

        public CGOLService CreateEmpty()
        {
            return serviceProvider.GetRequiredService<CGOLService>();
        }

        public CGOLService CreateBasicGame()
        {
            var context = serviceProvider.GetRequiredService<IPluginContext>();
            serviceProvider.GetRequiredService<CommonConceptsSetup>().Setup(context);
            serviceProvider.GetRequiredService<LanguageParserSetup>().Setup(context);
            context.Interpreter.AddConcept(new LoadBehaviorHandler(context));

            new GameStateSetup().Setup(context);
            return CreateEmpty();
        }

        public IInterpreter GetInterpolator()
        {
            return serviceProvider.GetRequiredService<IInterpreter>();
        }
    }
}
