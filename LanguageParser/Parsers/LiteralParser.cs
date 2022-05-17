using dk.itu.game.msc.cgdl.Parser.Tokens;

namespace dk.itu.game.msc.cgdl.Parser.Parsers
{
    public class LiteralParser : IParser<object?>
    {
        public object? Result { get; private set; }

        public void Parse(IParserQueue stack)
        {
            // {<string>|number_value}
            stack.ApplyToken<StringLiteral>((token) => Result = token.Value);
            stack.ApplyToken<NumberLiteral>((token) => Result = token.Value);

            if (Result == null)
                throw new GDLParserException($"Expected a string or number but found {stack.LookAhead1}");

            stack.DiscardToken();
        }
    }
}
