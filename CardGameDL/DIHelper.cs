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
            services.AddSingleton<EventRecorderFactory>();
            services.AddSingleton<IInterpreter>(new Interpreter());
            services.AddSingleton<ITimeProvider, UtcTime>();
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
    }
}
