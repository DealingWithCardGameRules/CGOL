using System.Text.RegularExpressions;

namespace dk.itu.game.msc.cgdl.LanguageParser
{
    public class TokenDefinition : ITokenDefinition
    {
        private readonly IToken token;
        private readonly Regex regex;

        public TokenDefinition(IToken type, string regexPattern)
        {
            token = type;
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
