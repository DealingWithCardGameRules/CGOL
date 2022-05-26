using dk.itu.game.msc.cgol.CommonConcepts.Handlers;
using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.Parser.Lexers;
using dk.itu.game.msc.cgol.Parser.Messages;

namespace dk.itu.game.msc.cgol.Parser
{
    public class LanguageParserSetup
    {
        private readonly Lexer lexer;
        private readonly CGOLParser parser;

        public LanguageParserSetup(LexerFactory lexer, CGOLParser parser)
        {
            if (lexer == null)
                throw new System.ArgumentNullException(nameof(lexer));

            this.lexer = lexer.Create();
            this.parser = parser ?? throw new System.ArgumentNullException(nameof(parser));
        }

        public void Setup(IPluginContext context)
        {
            // Setup command handlers
            context.Interpreter.AddConcept(new LoadCGOLHandler(context.TimeProvider, lexer, parser));
            context.Interpreter.AddConcept(new SimpleConditionalCommandHandler(context.Dispatcher));
            context.Interpreter.AddConcept(new AddInstantaniousEffectToCardHandler(context.TimeProvider));
            context.Interpreter.AddConcept(new AddPermanentEffectToCardHandler(context.TimeProvider));
            context.Interpreter.AddConcept(new PostponeCommandHandler(context.TimeProvider));

            // Setup event observers
            context.Interpreter.AddConcept(new DispatchLoadedCGOLEvent(context.Dispatcher));
        }
    }
}
