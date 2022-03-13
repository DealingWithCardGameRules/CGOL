using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.LanguageParser.Parsers;
using dk.itu.game.msc.cgdl.LanguageParser.Tokens;
using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.LanguageParser
{
    public class CGDLParser
    {
        private readonly IParserStackFactory factory;
        private readonly IParser<ICommand> conceptParser;
        private IParserStack stack;

        public CGDLParser(IParserStackFactory factory, IParser<ICommand> conceptParser)
        {
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
            this.conceptParser = conceptParser ?? throw new ArgumentNullException(nameof(conceptParser));
        }

        public IEnumerable<ICommand> Parse(IEnumerable<IToken> tokens)
        {
            stack = factory.Create(tokens);
            // [<action>\n]*
            
            while (stack.HasTokens) {
                ParseAction();
                yield return conceptParser.Result;
                stack.DiscardToken<SequenceTerminator>();
            }
        }

        private void ParseAction()
        {
            // <concept>
            conceptParser.Parse(stack);
        }
    }
}
