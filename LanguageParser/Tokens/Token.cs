namespace dk.itu.game.msc.cgol.Parser.Tokens
{
    public abstract class Token
    {
        public string RawValue { get; }

        public Token(string value)
        {
            RawValue = value;
        }

        public abstract string Type { get; }
    }
}