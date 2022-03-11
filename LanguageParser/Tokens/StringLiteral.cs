namespace dk.itu.game.msc.cgdl.LanguageParser.Tokens
{
    public class StringLiteral : IToken
    {
        public string? Value { get; private set; }

        public void Parse(string value)
        {
            // Remove quotes
            Value = value[1..^1];
        }
    }
}