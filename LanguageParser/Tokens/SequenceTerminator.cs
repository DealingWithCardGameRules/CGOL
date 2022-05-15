namespace dk.itu.game.msc.cgdl.LanguageParser.Tokens
{
    public class SequenceTerminator : Token
    {
        public override string Type => "symbol";

        public SequenceTerminator() : base(@"\n") { }

        public override string ToString()
        {
            return "End-Of-Line";
        }

    }
}