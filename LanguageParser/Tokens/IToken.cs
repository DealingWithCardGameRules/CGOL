using System;

namespace dk.itu.game.msc.cgdl.Parser.Tokens
{
    public abstract class Token
    {
        public string RawValue { get; }

        public Token(string value)
        {
            RawValue = value;
        }

        public abstract string Type { get; }
    }
}