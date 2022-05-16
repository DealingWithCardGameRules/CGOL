using dk.itu.game.msc.cgdl.LanguageParser.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;

namespace dk.itu.game.msc.cgdl.LanguageParser.Lexers
{
    public class LexerFactory
    {
        public Lexer Create()
        {
            var composite = new TokenDefinitionComposite(GetRequired().ToArray());
            return new Lexer(composite);
        }

        public Lexer CreateTolerant()
        {
            List<RegexTokenDefinition> definitions = GetRequired().ToList();
            definitions.Add(new RegexTokenDefinition((value) => new Symbol(value), "^."));
            var composite = new TokenDefinitionComposite(definitions.ToArray());

            return new Lexer(composite);
        }

        private IEnumerable<RegexTokenDefinition> GetRequired()
        {
            // Symbols
            yield return new RegexTokenDefinition((value) => new Comment(value), @"^/\*(.|\n)*?\*/");
            yield return new RegexTokenDefinition((value) => new Comment(value), "^//.*");
            yield return new RegexTokenDefinition((_) => new SequenceTerminator(), @"^\r?\n");
            yield return new RegexTokenDefinition((value) => new ParenthesesStart(value), @"^\(");
            yield return new RegexTokenDefinition((value) => new ParenthesesEnd(value), @"^\)");
            yield return new RegexTokenDefinition((value) => new Colon(value), "^:");
            yield return new RegexTokenDefinition((value) => new Tabulator(value), @"^(\t|\s{2})");

            // Keywords
            yield return new RegexTokenDefinition((value) => new PlayKeyword(value), @"^play\b");
            yield return new RegexTokenDefinition((value) => new IfKeyword(value), @"^if\b");
            yield return new RegexTokenDefinition((value) => new WhenKeyword(value), @"^when\b");
            yield return new RegexTokenDefinition((value) => new InstantaneousKeyword(value), @"^(instantaneous|inst)\b");
            yield return new RegexTokenDefinition((value) => new PermanentKeyword(value), @"^(permanent|perm)\b");

            // Literals
            yield return new RegexTokenDefinition((value) => new EventType(value), @$"^({string.Join('|', Enum.GetNames(typeof(SupportedEvent)))})\b");
            yield return new RegexTokenDefinition((value) => new NumberLiteral(value), @"^\d+");
            yield return new RegexTokenDefinition((value) => new StringLiteral(value), "^\"[^\"]*\"");

            // Concepts
            yield return new RegexTokenDefinition((value) => new Concept(value), "^[a-zA-Z]+");
        }
    }
}
