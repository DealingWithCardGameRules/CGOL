using dk.itu.game.msc.cgdl;
using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using Microsoft.Extensions.DependencyInjection;

namespace CardGameGL.AcceptTest.Drivers
{
    internal class GameDriver
    {
        ServiceProvider serviceProvider;

        public GameDriver()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddCardGameDescriptionLanguage();
            serviceCollection.AddSingleton(p => p.GetRequiredService<GDLFactory>().Create());
            serviceProvider = serviceCollection.BuildServiceProvider();
            serviceProvider.GetService<GDLSetup>()?.AddHandlers();
        }

        internal void AddStack(Guid id, int cards)
        {
            IDispatcher dispatcher = serviceProvider.GetService<IDispatcher>();
            dispatcher.Dispatch(new CreateStack(id));
        }
    }

    class BlankCard : ICard
    {
        public Guid Template => Guid.Empty;
        public Guid Instance => Guid.NewGuid();
        public string Name => "Pass";
    }
}
