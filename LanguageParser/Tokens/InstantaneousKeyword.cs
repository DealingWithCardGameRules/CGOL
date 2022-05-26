namespace dk.itu.game.msc.cgol.Parser.Tokens
{
    public class InstantaneousKeyword : Token
    {
        public override string Type => "keyword";

        public InstantaneousKeyword(string value) : base(value) { }
    }
}
