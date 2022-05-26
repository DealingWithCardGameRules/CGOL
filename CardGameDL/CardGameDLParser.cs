using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.Parser;
using dk.itu.game.msc.cgol.Parser.Lexers;
using System.Collections.Generic;
using System.IO;

namespace dk.itu.game.msc.cgol
{
    public class CardGameDLParser
    {
        private readonly CGOLParser parser;
        private Lexer lexer;

        public CardGameDLParser(LexerFactory factory, CGOLParser parser)
        {
            lexer = factory.Create();
            this.parser = parser ?? throw new System.ArgumentNullException(nameof(parser));
        }

        public IEnumerable<ICommand> Parse(string input)
        {
            return ParseLines(input.Split('\n'));
        }

        public IEnumerable<ICommand> Parse(StreamReader stream)
        {
            return ParseLines(Read(stream));
        }

        private IEnumerable<ICommand> ParseLines(IEnumerable<string> line)
        {
            var tokens = lexer.Tokenize(line);
            return parser.Parse(tokens);
        }

        private IEnumerable<string> Read(StreamReader stream)
        {
            while (!stream.EndOfStream)
                yield return stream.ReadLine();
        }
    }
}
