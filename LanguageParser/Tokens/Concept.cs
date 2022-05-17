namespace dk.itu.game.msc.cgdl.Parser.Tokens
{
    public class Concept : Token
    {
        public string Name { get; private set; }

        public override string Type => "concept";

        public Concept(string value) : base(value)
        {
            Name = value;
        }

        public override string ToString()
        {
            return $"Concept: {Name}";
        }
    }
}