using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.LanguageParser.Lexers;
using dk.itu.game.msc.cgdl.LanguageParser.Messages;

namespace dk.itu.game.msc.cgdl.LanguageParser
{
    public class LanguageParserSetup
    {
        private readonly Lexer lexer;
        private readonly CGDLParser parser;

        public LanguageParserSetup(LexerFactory lexer, CGDLParser parser)
        {
            if (lexer == null)
                throw new System.ArgumentNullException(nameof(lexer));

            this.lexer = lexer.Create();
            this.parser = parser ?? throw new System.ArgumentNullException(nameof(parser));
        }

        public void Setup(IPluginContext context)
        {
            // Setup command handlers
            context.Interpolator.AddConcept(new LoadCGDLHandler(context.TimeProvider, lexer, parser));

            // Setup event observers
            context.Interpolator.AddConcept(new DispatchLoadedCGDLEvent(context.Dispatcher));
        }
    }
}
