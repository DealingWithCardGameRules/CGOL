using dk.itu.game.msc.cgdl.LanguageParser.Tokens;

namespace dk.itu.game.msc.cgdl.LanguageParser.Lexers
{
    public class LexerFactory
    {
        public Lexer Create()
        {
            var composite = new TokenDefinitionComposite(
                new RegexTokenDefinition(new TokenFactory(() => new PlayKeyword()), "^play"),
                new RegexTokenDefinition(new TokenFactory(() => new NumberLiteral()), "^\\d+"),
                new RegexTokenDefinition(new TokenFactory(() => new StringLiteral()), "^\"[^\"]*\""),
                new RegexTokenDefinition(new TokenFactory(() => new Concept()), "^[a-zA-Z]+")
            );

            return new Lexer(composite);
        }
    }
}
