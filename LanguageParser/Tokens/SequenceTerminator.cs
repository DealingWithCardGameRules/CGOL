namespace dk.itu.game.msc.cgdl.LanguageParser.Tokens
{
    public class SequenceTerminator : IToken
    {
        public void Parse(string value) { }

        public override string ToString()
        {
            return "End-Of-Line";
        }

    }
}