using System;

namespace dk.itu.game.msc.cgol.Parser.Tokens
{
    public class NumberLiteral : Token
    {
        public int Value { get; private set; }
        public override string Type => "literal";

        public NumberLiteral(string value) : base(value)
        {
            Value = Convert.ToInt32(value);
        }

        public override string ToString()
        {
            return $"Number: {Value}";
        }
    }
}