namespace dk.itu.game.msc.cgdl.LanguageParser.Tokens
{
    internal class PlayKeyword : Token
    {
        public override string Type => "keyword";

        public PlayKeyword(string value) : base(value) {}

        public override string ToString()
        {
            return "Keyword: Play";
        }
    }
}
