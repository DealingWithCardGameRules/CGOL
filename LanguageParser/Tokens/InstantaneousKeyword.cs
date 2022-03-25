﻿namespace dk.itu.game.msc.cgdl.LanguageParser.Tokens
{
    public class InstantaneousKeyword : IToken
    {
        public string Type => "keyword";

        public string RawValue { get; private set; }

        public void Parse(string value)
        {
            RawValue = value;
        }
    }
}