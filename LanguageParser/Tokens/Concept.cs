namespace dk.itu.game.msc.cgdl.LanguageParser.Tokens
{
    public class Concept : IToken
    {
        public string Name { get; private set; }

        public string RawValue { get; private set; }

        public string Type => "concept";

        public void Parse(string value)
        {
            RawValue = value;
            Name = value;
        }

        public override string ToString()
        {
            return $"Concept: {Name}";
        }
    }
}