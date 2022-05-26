namespace dk.itu.game.msc.cgol.Parser.Parsers
{
    public interface IParser<T>
    {
        T Result { get; }
        void Parse(IParserQueue queue);
    }
}