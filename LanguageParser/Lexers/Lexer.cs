using dk.itu.game.msc.cgol.Parser.Tokens;
using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgol.Parser.Lexers
{
    public class Lexer
    {
        private readonly ITokenDefinition tokenDefinition;

        public Lexer(ITokenDefinition tokenDefinition)
        {
            this.tokenDefinition = tokenDefinition;
        }

        public IEnumerable<Token> Tokenize(params string[] input)
        {
            return Tokenize((IEnumerable<string>)input);
        }

        public IEnumerable<Token> Tokenize(IEnumerable<string> input)
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
                        var skip = Math.Max(1, match.Length);
                        remaining = remaining[skip..];
                    }
                    else
                    {
                        remaining = remaining[1..];
                    }
                }
            }
            yield return new SequenceTerminator();
        }
    }
}
