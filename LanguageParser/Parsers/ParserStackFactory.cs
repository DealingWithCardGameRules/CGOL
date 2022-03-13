using dk.itu.game.msc.cgdl.LanguageParser.Tokens;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.LanguageParser.Parsers
{
    public class ParserStackFactory : IParserStackFactory
    {
        public IParserStack Create(IEnumerable<IToken> tokens)
        {
            return new ParserStack(tokens);
        }
    }
}