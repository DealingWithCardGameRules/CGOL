namespace dk.itu.game.msc.cgol.Parser.Tokens
{
    public class Symbol : Token
    {
        public override string Type => "symbol";

        public Symbol(string value) : base(value) { }
    }

    public class ParenthesesStart : Symbol
    {
        public ParenthesesStart(string value) : base(value) { }
    }

    public class ParenthesesEnd : Symbol
    {
        public ParenthesesEnd(string value) : base(value) { }
    }

    public class Colon : Symbol
    {
        public Colon(string value) : base(value) { }
    }

    public class Tabulator : Symbol
    {
        public Tabulator(string value) : base(value) { }
    }
}
