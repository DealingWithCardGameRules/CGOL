namespace dk.itu.game.msc.cgdl.LanguageParser.Tokens
{
    public class PermanentKeyword : Token
    {
        public override string Type => "keyword";

        public PermanentKeyword(string value) : base(value) { }
    }
}
