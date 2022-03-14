namespace dk.itu.game.msc.cgdl.LanguageParser.Parsers
{
    public interface IParser<T>
    {
        T Result { get; }
        void Parse(IParserQueue stack);
    }
}