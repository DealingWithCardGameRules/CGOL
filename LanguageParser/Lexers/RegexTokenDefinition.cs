using dk.itu.game.msc.cgdl.LanguageParser.Tokens;
using System;
using System.Text.RegularExpressions;

namespace dk.itu.game.msc.cgdl.LanguageParser.Lexers
{
    public class RegexTokenDefinition : ITokenDefinition
    {
        private readonly Regex regex;
        private readonly Func<string, Token> factory;

        public RegexTokenDefinition(Func<string, Token> factory, string regexPattern)
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
                return new TokenMatch(factory.Invoke(match.Value))
                {
                    Length = match.Length
                };
            }
            return null;
        }
    }
}
