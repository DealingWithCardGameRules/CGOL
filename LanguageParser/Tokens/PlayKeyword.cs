﻿namespace dk.itu.game.msc.cgdl.LanguageParser.Tokens
{
    internal class PlayKeyword : IToken
    {
        public string RawValue { get; private set; }

        public string Type => "keyword";

        public void Parse(string value) 
        {
            RawValue = value;
        }

        public override string ToString()
        {
            return "Keyword: Play";
        }
    }
}
