using dk.itu.game.msc.cgdl.LanguageParser.Tokens;
using System;
using System.Text.RegularExpressions;

namespace dk.itu.game.msc.cgdl.LanguageParser.Lexers
{
    public class RegexTokenDefinition : ITokenDefinition
    {
        private readonly IToken token;
        private readonly Regex regex;

        public RegexTokenDefinition(IToken token, string regexPattern)
        {
            if (string.IsNullOrEmpty(regexPattern))
                throw new ArgumentNullException(nameof(regexPattern));

            this.token = token ?? throw new ArgumentNullException(nameof(token));
            regex = new Regex(regexPattern, RegexOptions.IgnoreCase);
        }

        public ITokenMatch? Match(string input)
        {
            var match = regex.Match(input);
            if (match.Success)
            {
                string remainingText = string.Empty;
                if (match.Length != input.Length)
                    remainingText = input.Substring(match.Length);

                return new TokenMatch(token)
                {
                    Value = match.Value,
                    RemainingText = remainingText
                };
            }
            return null;
        }
    }
}
