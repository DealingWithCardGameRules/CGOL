using dk.itu.game.msc.cgol.CommonConcepts;
using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.GameEvents;
using dk.itu.game.msc.cgol.Parser;
using dk.itu.game.msc.cgol.Parser.Lexers;
using dk.itu.game.msc.cgol.Parser.Parsers;
using Microsoft.Extensions.DependencyInjection;

namespace dk.itu.game.msc.cgol
{
    public static class DIHelper
    {
        public static void AddCGOLBasics(this IServiceCollection services)
        {
            services.AddSingleton<EventLogFactory>();
            services.AddSingleton<DispatcherFactory>();
            services.AddSingleton<IInterpreter, Interpreter>();
            services.AddSingleton<ITimeProvider, UtcTime>();
            services.AddSingleton<IPluginContext, PluginContext>();
        }

        public static void AddCGOLParser(this IServiceCollection services)
        {
            services.AddSingleton<IParserQueueFactory, ParserQueueFactory>();
            services.AddSingleton<IParser<object?>, LiteralParser>();
            services.AddSingleton<IParser<ICommand?>, ConceptParser<ICommand?>>();
            services.AddSingleton<IParser<IQuery<bool>?>, ConceptParser<IQuery<bool>?>>();
            services.AddSingleton<CGOLParser>();
            services.AddSingleton<LexerFactory>();
            services.AddSingleton<LanguageParserSetup>();
        }

        public static void AddCGOLService(this IServiceCollection services)
        {
            services.AddSingleton(p => p.GetRequiredService<DispatcherFactory>().Create());
            services.AddSingleton<CommonConceptsSetup>();
            services.AddSingleton<CGOLService>();
        }
    }
}
