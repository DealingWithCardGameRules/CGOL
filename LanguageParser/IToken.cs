using System;

namespace dk.itu.game.msc.cgdl.LanguageParser
{
    public interface IToken {}

    public class StringLiteral : IToken {}
    public class NumberLiteral : IToken { }

    public class Keyword : IToken {}

    public class Concept : IToken {}
}