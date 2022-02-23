using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.GameEvents;
using dk.itu.game.msc.cgdl.GameState;
using Microsoft.Extensions.DependencyInjection;

namespace dk.itu.game.msc.cgdl
{
    public static class DIHelper
    {
        public static void AddCardGameDescriptionLanguage(this IServiceCollection services)
        {
            services.AddSingleton<EventLoggerFactory>();
            services.AddSingleton<GDLFactory>();
            services.AddSingleton<Interpolator>();
            services.AddSingleton<Game>();
            services.AddSingleton<GDLSetup>();
            services.AddSingleton<ITimeProvider>(new UtcTime());
        }
    }
}
