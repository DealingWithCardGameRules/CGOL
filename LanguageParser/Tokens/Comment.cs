namespace dk.itu.game.msc.cgdl.Parser.Tokens
{
    public class Comment : Token
    {
        public override string Type => "comment";

        public Comment(string value) : base(value) { }
    }
}
