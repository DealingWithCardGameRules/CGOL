using dk.itu.game.msc.cgdl.LanguageParser.Lexers;
using dk.itu.game.msc.cgdl.LanguageParser.Tokens;
using System.Text;

namespace CardGameWebApp.Client
{
    public class Highlighter
    {
        private readonly Lexer lexer;
        public Highlighter()
        {
            lexer = new LexerFactory().CreateTolerant();
        }

        public string Highlight(string input)
        {
            var output = new StringBuilder();
            foreach (var token in lexer.Tokenize(input))
            {
                if (token is SequenceTerminator)
                {
                    output.Append("<br \\>");
                }
                else if (token is StringLiteral literal)
                {
                    output.Append($"<span class=\"token symbol\">\"</span><span class=\"token {token.Type}\">{literal.Value}</span><span class=\"token symbol\">\"</span>");
                }
                else if (token is Symbol)
                {
                    output.Append(token.RawValue);
                }
                else
                {
                    output.Append($"<span class=\"token {token.Type}\">{token.RawValue}</span>");
                }
            }
            var debug = output.ToString();
            return debug;
        }
    }
}
