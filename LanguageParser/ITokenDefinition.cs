namespace dk.itu.game.msc.cgdl.LanguageParser
{
    public interface ITokenDefinition
    {
        ITokenMatch? Match(string input);
    }
}