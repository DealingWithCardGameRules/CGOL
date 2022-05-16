namespace dk.itu.game.msc.cgdl.LanguageParser.Tokens
{
    public class InstantaneousKeyword : Token
    {
        public override string Type => "keyword";

        public InstantaneousKeyword(string value) : base(value) { }
    }
}
