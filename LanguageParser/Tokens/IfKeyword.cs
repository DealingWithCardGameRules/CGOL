﻿namespace dk.itu.game.msc.cgol.Parser.Tokens
{
    internal class IfKeyword : Token
    {
        public override string Type => "keyword";

        public IfKeyword(string value) : base(value) { }

        public override string ToString()
        {
            return "Keyword: If";
        }
    }
}
