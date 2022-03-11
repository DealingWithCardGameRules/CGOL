using dk.itu.game.msc.cgdl.LanguageParser.Tokens;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.LanguageParser.Lexers
{
    public class Lexer
    {
        private readonly ITokenDefinition tokenDefinition;

        public Lexer(ITokenDefinition tokenDefinition)
        {
            this.tokenDefinition = tokenDefinition;
        }

        public IEnumerable<IToken> Tokenize(IEnumerable<string> input)
        {
            foreach (var text in input)
            {
                var remaining = text;

                while (!string.IsNullOrWhiteSpace(remaining))
                {
                    var match = tokenDefinition.Match(remaining);
                    if (match != null)
                    {
                        yield return match.Token;
                        remaining = match.RemainingText;
                    }
                    else
                    {
                        remaining = remaining[1..];
                    }
                }

                yield return new SequenceTerminator();
            }
        }
    }
}
