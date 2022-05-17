namespace dk.itu.game.msc.cgdl.Parser.Tokens
{
    public class PermanentKeyword : Token
    {
        public override string Type => "keyword";

        public PermanentKeyword(string value) : base(value) { }
    }
}
