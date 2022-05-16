using dk.itu.game.msc.cgdl.LanguageParser.Tokens;
using System;

namespace dk.itu.game.msc.cgdl.LanguageParser.Parsers
{
    public interface IParserQueue
    {
        Token LookAhead1 { get; }
        Token LookAhead2 { get; }

        void DiscardToken();
        void DiscardToken<T>();

        T ReadToken<T>() where T : Token;
        void ApplyToken<T>(Action<T> callback) where T : Token;
        bool HasTokens { get; }
    }
}