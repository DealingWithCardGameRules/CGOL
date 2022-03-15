using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.GameState;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace dk.itu.game.msc.cgdl.Representation
{
    public class SessionFactory
    {
        public Session Create(Guid id)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddCGDLBasics();
            serviceCollection.AddCGDLService();
            var serviceProvider = serviceCollection.BuildServiceProvider();
            serviceProvider.GetService<SimpleGameSetup>()?.AddHandlers();
            new GameStateSetup().Setup(serviceProvider.GetRequiredService<IInterpolator>());
            return new Session(id, serviceProvider);
        }
    }
}
