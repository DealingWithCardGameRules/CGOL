using System;

namespace dk.itu.game.msc.cgdl.LanguageParser.Tokens
{
    public interface IToken
    {
        string Type { get; }
        string RawValue { get; }
        void Parse(string value);
    }
}