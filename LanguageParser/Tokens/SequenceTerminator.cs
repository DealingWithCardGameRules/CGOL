namespace dk.itu.game.msc.cgdl.LanguageParser.Tokens
{
    public class SequenceTerminator : IToken
    {
        public string RawValue => @"\n";

        public string Type => "symbol";

        public void Parse(string value) { }

        public override string ToString()
        {
            return "End-Of-Line";
        }

    }
}