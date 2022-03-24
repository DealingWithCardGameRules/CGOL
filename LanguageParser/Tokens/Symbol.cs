namespace dk.itu.game.msc.cgdl.LanguageParser.Tokens
{
    public class Symbol : IToken
    {
        public string Type => "symbol";

        public string RawValue { get; private set; }

        public void Parse(string value)
        {
            RawValue = value;
        }
    }

    public class ParenthesesStart : Symbol { }

    public class ParenthesesEnd : Symbol { }
}
