using dk.itu.game.msc.cgol.Parser.Tokens;
using System;

namespace dk.itu.game.msc.cgol.Parser.Lexers
{
    public class TokenMatch : ITokenMatch
    {
        public Token Token { get; set; }
        //public string RemainingText { get; set; } = string.Empty;
        public int Length { get; set; } = 0;

        public TokenMatch(Token token)
        {
            Token = token ?? throw new ArgumentNullException(nameof(token));
        }
    }
}
