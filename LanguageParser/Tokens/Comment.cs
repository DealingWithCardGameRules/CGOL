namespace dk.itu.game.msc.cgdl.LanguageParser.Tokens
{
    public class Comment : IToken
    {
        public string Type => "comment";

        public string RawValue { get; private set; }

        public void Parse(string value)
        {
            RawValue = value;
        }
    }
}
