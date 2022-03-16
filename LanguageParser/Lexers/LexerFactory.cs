﻿using dk.itu.game.msc.cgdl.LanguageParser.Tokens;

namespace dk.itu.game.msc.cgdl.LanguageParser.Lexers
{
    public class LexerFactory
    {
        public Lexer Create()
        {
            var composite = new TokenDefinitionComposite(
                new RegexTokenDefinition(new TokenFactory(() => new PlayKeyword()), "^play\\b"),
                new RegexTokenDefinition(new TokenFactory(() => new NumberLiteral()), "^\\d+"),
                new RegexTokenDefinition(new TokenFactory(() => new StringLiteral()), "^\"[^\"]*\""),
                new RegexTokenDefinition(new TokenFactory(() => new Concept()), "^[a-zA-Z]+")
            );

            return new Lexer(composite);
        }

        public Lexer CreateTolerant()
        {
            var composite = new TokenDefinitionComposite(
                new RegexTokenDefinition(new TokenFactory(() => new PlayKeyword()), "^play\\b"),
                new RegexTokenDefinition(new TokenFactory(() => new NumberLiteral()), "^\\d+"),
                new RegexTokenDefinition(new TokenFactory(() => new StringLiteral()), "^\"[^\"]*\""),
                new RegexTokenDefinition(new TokenFactory(() => new Concept()), "^[a-zA-Z]+"),
                new RegexTokenDefinition(new TokenFactory(() => new Symbol()), "^.")
            );

            return new Lexer(composite);

        }
    }
}
