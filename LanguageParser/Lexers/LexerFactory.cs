using dk.itu.game.msc.cgdl.LanguageParser.Tokens;
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
            definitions.Add(new RegexTokenDefinition(new TokenFactory(() => new Symbol()), "^."));
            var composite = new TokenDefinitionComposite(definitions.ToArray());

            return new Lexer(composite);
        }

        private IEnumerable<RegexTokenDefinition> GetRequired()
        {
            yield return new RegexTokenDefinition(new TokenFactory(() => new Comment()), @"^/\*([^*/]|\n)*\*/??");
            yield return new RegexTokenDefinition(new TokenFactory(() => new Comment()), "^//.*");
            yield return new RegexTokenDefinition(new TokenFactory(() => new SequenceTerminator()), @"^\r?\n");
            yield return new RegexTokenDefinition(new TokenFactory(() => new PlayKeyword()), @"^play\b");
            yield return new RegexTokenDefinition(new TokenFactory(() => new IfKeyword()), @"^if\b");
            yield return new RegexTokenDefinition(new TokenFactory(() => new ParenthesesStart()), @"^\(");
            yield return new RegexTokenDefinition(new TokenFactory(() => new ParenthesesEnd()), @"^\)");
            yield return new RegexTokenDefinition(new TokenFactory(() => new NumberLiteral()), @"^\d+");
            yield return new RegexTokenDefinition(new TokenFactory(() => new StringLiteral()), "^\"[^\"]*\"");
            yield return new RegexTokenDefinition(new TokenFactory(() => new Concept()), "^[a-zA-Z]+");
        }
    }
}
