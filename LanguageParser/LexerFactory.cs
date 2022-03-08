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
                new TokenDefinition(new Keyword(), "^play"),
                new TokenDefinition(new NumberLiteral(), "^\\d+"),
                new TokenDefinition(new StringLiteral(), "^\"[^\"]*\""),
                new TokenDefinition(new Concept(), "^[a-zA-Z]*")
            );
            return new Lexer(composite); ;
        }
    }
}
