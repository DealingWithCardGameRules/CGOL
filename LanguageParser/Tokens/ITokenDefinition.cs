namespace dk.itu.game.msc.cgdl.LanguageParser.Tokens
{
    public interface ITokenDefinition
    {
        ITokenMatch? Match(string input);
    }
}