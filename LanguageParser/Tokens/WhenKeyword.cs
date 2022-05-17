﻿namespace dk.itu.game.msc.cgdl.Parser.Tokens
{
    internal class WhenKeyword : Token
    {
        public override string Type => "keyword";

        public WhenKeyword(string value) : base(value) { }

        public override string ToString()
        {
            return "Keyword: When";
        }
    }
}
