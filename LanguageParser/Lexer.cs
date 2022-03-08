using System.Collections.Generic;

namespace dk.itu.game.msc.cgdl.LanguageParser
{
    public class Lexer
    {
        private readonly List<ITokenDefinition> definitions;

        public Lexer()
        {
            definitions = new List<ITokenDefinition>();
        }

        public void Add(ITokenDefinition definition)
        {
            definitions.Add(definition);
        }

        public IEnumerable<IToken> Tokenize(IEnumerable<string> input)
        {
            foreach (var text in input)
            {
                var remaining = text;

                while (!string.IsNullOrWhiteSpace(remaining))
                {
                    var match = FindMatch(remaining);
                    if (match != null)
                    {
                        yield return match;
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

        private TokenMatch? FindMatch(string text)
        {
            foreach (var definition in definitions)
            {
                var match = definition.Match(text);
                if (match != null)
                    return match;
            }
            return null;
        }
    }
}
