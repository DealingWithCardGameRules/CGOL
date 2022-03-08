using System;

namespace dk.itu.game.msc.cgdl.LanguageParser
{
    public class TokenMatch : IToken
    {
        public ITokenType Type { get; set; }
        public string Value { get; set; } = string.Empty;
        public string RemainingText { get; set; } = string.Empty;

        public TokenMatch(ITokenType tokenType)
        {
            Type = tokenType ?? throw new ArgumentNullException(nameof(tokenType));
        }
    }
}
