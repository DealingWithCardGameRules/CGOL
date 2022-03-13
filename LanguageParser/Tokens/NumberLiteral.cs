using System;

namespace dk.itu.game.msc.cgdl.LanguageParser.Tokens
{
    public class NumberLiteral : IToken
    {
        public int Value { get; private set; }
        public void Parse(string value)
        {
            Value = Convert.ToInt32(value);
        }

        public override string ToString()
        {
            return $"Number ({Value})";
        }
    }
}