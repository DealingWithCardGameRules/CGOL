using dk.itu.game.msc.cgdl.LanguageParser.Tokens;
using System;
using System.Text.RegularExpressions;

namespace dk.itu.game.msc.cgdl.LanguageParser.Lexers
{
    public class RegexTokenDefinition : ITokenDefinition
    {
        private readonly Regex regex;
        private readonly ITokenFactory factory;

        public RegexTokenDefinition(ITokenFactory factory, string regexPattern)
        {
            if (string.IsNullOrEmpty(regexPattern))
                throw new ArgumentNullException(nameof(regexPattern));

            regex = new Regex(regexPattern, RegexOptions.IgnoreCase);
            this.factory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        public ITokenMatch? Match(string input)
        {
            var match = regex.Match(input);
            if (match.Success)
            {
                string remainingText = string.Empty;
                if (match.Length != input.Length)
                    remainingText = input.Substring(match.Length);

                return new TokenMatch(factory.Create(match.Value))
                {
                    RemainingText = remainingText
                };
            }
            return null;
        }
    }
}
