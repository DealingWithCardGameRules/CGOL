using dk.itu.game.msc.cgdl.CommonConcepts;
using dk.itu.game.msc.cgdl.Distribution;
using dk.itu.game.msc.cgdl.GameEvents;
using dk.itu.game.msc.cgdl.LanguageParser;
using dk.itu.game.msc.cgdl.LanguageParser.Lexers;
using dk.itu.game.msc.cgdl.LanguageParser.Parsers;
using Microsoft.Extensions.DependencyInjection;

namespace dk.itu.game.msc.cgdl
{
    public static class DIHelper
    {
        public static void AddCGDLBasics(this IServiceCollection services)
        {
            services.AddSingleton<EventLoggerFactory>();
            services.AddSingleton<DispatcherFactory>();
            services.AddSingleton<IInterpreter, Interpolator>();
            services.AddSingleton<ITimeProvider, UtcTime>();
            services.AddSingleton<IPluginContext, PluginContext>();
        }

        public static void AddCGDLParser(this IServiceCollection services)
        {
            services.AddSingleton<IParserQueueFactory, ParserQueueFactory>();
            services.AddSingleton<IParser<object?>, LiteralParser>();
            services.AddSingleton<IParser<ICommand?>, CommandConceptParser>();
            services.AddSingleton<IParser<IQuery<bool>?>, QueryConceptParser>();
            services.AddSingleton<CGDLParser>();
            services.AddSingleton<LexerFactory>();
            services.AddSingleton<CardGameDLParser>();
            services.AddSingleton<LanguageParserSetup>();
        }

        public static void AddCGDLService(this IServiceCollection services)
        {
            services.AddSingleton(p => p.GetRequiredService<DispatcherFactory>().Create());
            services.AddSingleton<CommonConceptsSetup>();
            services.AddSingleton<CGDLService>();
        }
    }
}
