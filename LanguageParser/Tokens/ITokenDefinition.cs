namespace dk.itu.game.msc.cgol.Parser.Tokens
{
    public interface ITokenDefinition
    {
        ITokenMatch? Match(string input);
    }
}