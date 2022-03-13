using Microsoft.Extensions.DependencyInjection;
using System;

namespace dk.itu.game.msc.cgdl.Representation
{
    public class SessionFactory
    {
        public SessionFactory()
        {

        }

        public Session Create(Guid id)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddCardGameDescriptionLanguage();
            serviceCollection.AddSingleton(p => p.GetRequiredService<GDLFactory>().Create());
            
            var serviceProvider = serviceCollection.BuildServiceProvider();
            serviceProvider.GetService<SimpleGameSetup>()?.AddHandlers();
            return new Session(id, serviceProvider);
        }
    }
}
