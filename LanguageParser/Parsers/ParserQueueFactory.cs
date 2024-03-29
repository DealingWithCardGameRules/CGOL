﻿using dk.itu.game.msc.cgol.Parser.Tokens;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgol.Parser.Parsers
{
    public class ParserQueueFactory : IParserQueueFactory
    {
        public IParserQueue Create(IEnumerable<Token> tokens)
        {
            return new ParserQueue(tokens);
        }
    }
}