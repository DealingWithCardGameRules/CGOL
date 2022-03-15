namespace dk.itu.game.msc.cgdl.LanguageParser.Tokens
{
    internal class PlayKeyword : IToken
    {
        public void Parse(string value) { }

        public override string ToString()
        {
            return "Keyword: Play";
        }
    }
}
