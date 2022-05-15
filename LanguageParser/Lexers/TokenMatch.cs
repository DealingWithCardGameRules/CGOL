using dk.itu.game.msc.cgdl.LanguageParser.Tokens;
using System;

namespace dk.itu.game.msc.cgdl.LanguageParser.Lexers
{
    public class TokenMatch : ITokenMatch
    {
        public IToken Token { get; set; }
        //public string RemainingText { get; set; } = string.Empty;
        public int CharacterLength { get; set; } = 0;

        public TokenMatch(IToken token)
        {
            Token = token ?? throw new ArgumentNullException(nameof(token));
        }
    }
}
