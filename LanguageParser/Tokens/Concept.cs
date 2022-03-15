namespace dk.itu.game.msc.cgdl.LanguageParser.Tokens
{
    public class Concept : IToken
    {
        public string Name { get; private set; }

        public void Parse(string value)
        {
            Name = value;
        }

        public override string ToString()
        {
            return $"Concept: {Name}";
        }
    }
}