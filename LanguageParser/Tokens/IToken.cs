using System;

namespace dk.itu.game.msc.cgdl.LanguageParser.Tokens
{
    public interface IToken
    {
        void Parse(string value);
    }
}