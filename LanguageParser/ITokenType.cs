using System;

namespace dk.itu.game.msc.cgdl.LanguageParser
{
    internal interface ITokenType
    {
        string Name { get; }
    }

    internal class Keyword : ITokenType
    {
        public string Name { get; set; } = "keyword";
    }

    internal class Literate : ITokenType
    {
        public string Name { get; set; } = "string";
        public Type Type { get; set; } = typeof(string);
    }

    internal class Concept : ITokenType
    {
        public string Name { get; set; } = "concept";
    }
}
