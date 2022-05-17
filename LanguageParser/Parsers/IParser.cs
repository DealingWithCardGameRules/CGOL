namespace dk.itu.game.msc.cgdl.Parser.Parsers
{
    public interface IParser<T>
    {
        T Result { get; }
        void Parse(IParserQueue queue);
    }
}