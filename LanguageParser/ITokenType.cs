using System;

namespace dk.itu.game.msc.cgdl.LanguageParser
{
    public interface ITokenType
    {
        string Name { get; }
    }

    public class Keyword : ITokenType
    {
        public string Name { get; set; } = "keyword";
    }

    public class Literate : ITokenType
    {
        public string Name { get; set; } = "string";
        public Type Type { get; set; } = typeof(string);
    }

    public class Concept : ITokenType
    {
        public string Name { get; set; } = "concept";
    }
}
