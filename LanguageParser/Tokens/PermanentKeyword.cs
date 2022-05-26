namespace dk.itu.game.msc.cgol.Parser.Tokens
{
    public class PermanentKeyword : Token
    {
        public override string Type => "keyword";

        public PermanentKeyword(string value) : base(value) { }
    }
}
