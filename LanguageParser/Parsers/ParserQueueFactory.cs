using dk.itu.game.msc.cgdl.LanguageParser.Tokens;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.LanguageParser.Parsers
{
    public class ParserQueueFactory : IParserQueueFactory
    {
        public IParserQueue Create(IEnumerable<Token> tokens)
        {
            return new ParserQueue(tokens);
        }
    }
}