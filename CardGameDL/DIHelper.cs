using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.GameEvents;
using dk.itu.game.msc.cgdl.GameState;
using dk.itu.game.msc.cgdl.LanguageParser;
using dk.itu.game.msc.cgdl.LanguageParser.Lexers;
using dk.itu.game.msc.cgdl.LanguageParser.Parsers;
using Microsoft.Extensions.DependencyInjection;

namespace dk.itu.game.msc.cgdl
{
    public static class DIHelper
    {
        public static void AddCardGameDescriptionLanguage(this IServiceCollection services)
        {
            services.AddSingleton<EventLoggerFactory>();
            services.AddSingleton<GDLFactory>();
            services.AddSingleton<IInterpolator, Interpolator>();
            services.AddSingleton<Game>();
            services.AddSingleton<Library>();
            services.AddSingleton<SimpleGameSetup>();
            services.AddSingleton<ITimeProvider>(new UtcTime());
            services.AddSingleton<IParserQueueFactory, ParserQueueFactory>();
            services.AddSingleton<IParser<object>, LiteralParser>();
            services.AddSingleton<IParser<ICommand>, ConceptParser>();
            services.AddSingleton<CGDLParser>();
            services.AddSingleton<LexerFactory>();
            services.AddSingleton<CardGameDLParser>();
        }
    }
}
