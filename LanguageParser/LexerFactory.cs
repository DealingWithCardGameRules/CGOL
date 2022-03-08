namespace dk.itu.game.msc.cgdl.LanguageParser
{
    internal class LexerFactory
    {
        public LexerFactory()
        {

        }

        public Lexer Create()
        {
            var lexer = new Lexer();
            lexer.Add(new TokenDefinition(new Keyword { Name = "play" }, "^play"));
            lexer.Add(new TokenDefinition(new Literate { Name = "number" }, "^\\d+"));
            lexer.Add(new TokenDefinition(new Literate { Name = "string" }, "^\"[^\"]*\""));

            // Concepts
            lexer.Add(new TokenDefinition(new Concept(), "^[a-zA-Z]*"));
            return lexer;
        }
    }
}
