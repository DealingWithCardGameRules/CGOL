namespace dk.itu.game.msc.cgdl.LanguageParser.Tokens
{
    public class Comment : Token
    {
        public override string Type => "comment";

        public Comment(string value) : base(value) { }
    }
}
