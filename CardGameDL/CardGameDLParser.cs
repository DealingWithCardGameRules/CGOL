using dk.itu.game.msc.cgdl.Distribution;
using dk.itu.game.msc.cgdl.LanguageParser;
using dk.itu.game.msc.cgdl.LanguageParser.Lexers;
using System.Collections.Generic;
using System.IO;

namespace dk.itu.game.msc.cgdl
{
    public class CardGameDLParser
    {
        private readonly CGDLParser parser;
        private Lexer lexer;

        public CardGameDLParser(LexerFactory factory, CGDLParser parser)
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
