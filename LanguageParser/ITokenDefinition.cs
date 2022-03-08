namespace dk.itu.game.msc.cgdl.LanguageParser
{
    public interface ITokenDefinition
    {
        TokenMatch? Match(string input);
    }
}