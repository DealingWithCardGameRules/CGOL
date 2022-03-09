namespace dk.itu.game.msc.cgdl.LanguageParser
{
    internal class LexerFactory
    {
        public LexerFactory()
        {

        }

        public Lexer Create()
        {
            var composite = new TokenDefinitionComposite(
                new RegexTokenDefinition(new Keyword(), "^play"),
                new RegexTokenDefinition(new NumberLiteral(), "^\\d+"),
                new RegexTokenDefinition(new StringLiteral(), "^\"[^\"]*\""),
                new RegexTokenDefinition(new Concept(), "^[a-zA-Z]*")
            );
            return new Lexer(composite); ;
        }
    }
}
