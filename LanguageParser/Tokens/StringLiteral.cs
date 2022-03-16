namespace dk.itu.game.msc.cgdl.LanguageParser.Tokens
{
    public class StringLiteral : IToken
    {
        public string? Value { get; private set; }

        public string RawValue { get; private set; } = "\"\"";

        public string Type => "literal";

        public void Parse(string value)
        {
            RawValue = value;
            // Remove quotes
            Value = value[1..^1];
        }

        public override string ToString()
        {
            return $"String: \"{Value}\"";
        }

    }
}