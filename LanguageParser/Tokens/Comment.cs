namespace dk.itu.game.msc.cgol.Parser.Tokens
{
    public class Comment : Token
    {
        public override string Type => "comment";

        public Comment(string value) : base(value) { }
    }
}
