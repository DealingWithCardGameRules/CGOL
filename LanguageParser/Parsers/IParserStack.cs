using dk.itu.game.msc.cgdl.LanguageParser.Tokens;
using System;

namespace dk.itu.game.msc.cgdl.LanguageParser.Parsers
{
    public interface IParserStack
    {
        IToken LookAhead1 { get; }
        IToken LookAhead2 { get; }

        void DiscardToken();
        void DiscardToken<T>();

        IToken ReadToken(Type type);
        T ReadToken<T>() where T : IToken;
        void ApplyToken<T>(Action<T> callback) where T : IToken;
        bool HasTokens { get; }
    }
}