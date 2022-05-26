using dk.itu.game.msc.cgol.Parser.Tokens;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgol.Parser.Parsers
{
    public interface IParserQueueFactory
    {
        IParserQueue Create(IEnumerable<Token> tokens);
    }
}