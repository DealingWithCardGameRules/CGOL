namespace dk.itu.game.msc.cgdl.Parser.Tokens
{
    public interface ITokenDefinition
    {
        ITokenMatch? Match(string input);
    }
}