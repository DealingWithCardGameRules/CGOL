using dk.itu.game.msc.cgdl.LanguageParser.Tokens;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.LanguageParser.Parsers
{
    public interface IParserStackFactory
    {
        IParserStack Create(IEnumerable<IToken> tokens);
    }
}