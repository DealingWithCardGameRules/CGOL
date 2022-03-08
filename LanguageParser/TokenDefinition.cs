using System.Text.RegularExpressions;

namespace dk.itu.game.msc.cgdl.LanguageParser
{
    internal class TokenDefinition
    {
        private readonly ITokenType tokenType;
        private readonly Regex regex;

        public TokenDefinition(ITokenType type, string regexPattern)
        {
            tokenType = type;
            regex = new Regex(regexPattern, RegexOptions.IgnoreCase);
        }

        public TokenMatch? Match(string input)
        {
            var match = regex.Match(input);
            if (match.Success)
            {
                string remainingText = string.Empty;
                if (match.Length != input.Length)
                    remainingText = input.Substring(match.Length);

                return new TokenMatch
                {
                    Type = tokenType,
                    Value = match.Value,
                    RemainingText = remainingText
                };
            }
            return null;
        }
    }

    internal class TokenMatch : IToken
    {
        public ITokenType Type { get; set; }
        public string Value { get; set; }
        public string RemainingText { get; set; }
    }
}
