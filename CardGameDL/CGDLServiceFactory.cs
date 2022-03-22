using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.GameState;
using dk.itu.game.msc.cgdl.LanguageParser;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace dk.itu.game.msc.cgdl
{
    public class CGDLServiceFactory
    {
        readonly IServiceProvider serviceProvider;
        public CGDLServiceFactory()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddCGDLBasics();
            serviceCollection.AddCGDLParser();
            serviceCollection.AddCGDLService();
            serviceProvider = serviceCollection.BuildServiceProvider();
        }

        public CGDLService CreateEmpty()
        {
            return serviceProvider.GetRequiredService<CGDLService>();
        }

        public CGDLService CreateBasicGame()
        {
            var context = serviceProvider.GetRequiredService<IPluginContext>();
            serviceProvider.GetRequiredService<SimpleGameSetup>().AddHandlers();
            serviceProvider.GetRequiredService<LanguageParserSetup>().Setup(context);
            new GameStateSetup().Setup(context);
            return CreateEmpty();
        }
    }
}
