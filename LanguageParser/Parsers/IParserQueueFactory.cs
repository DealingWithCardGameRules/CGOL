using dk.itu.game.msc.cgdl.LanguageParser.Tokens;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.LanguageParser.Parsers
{
    public interface IParserQueueFactory
    {
        IParserQueue Create(IEnumerable<Token> tokens);
    }
}