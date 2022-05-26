namespace dk.itu.game.msc.cgol.Parser.Tokens
{
    public class StringLiteral : Token
    {
        public string? Value { get; private set; }

        public override string Type => "literal";

        public StringLiteral(string value) : base(value)
        {
            // Remove quotes
            Value = value[1..^1];
        }

        public override string ToString()
        {
            return $"String: \"{Value}\"";
        }

    }
}