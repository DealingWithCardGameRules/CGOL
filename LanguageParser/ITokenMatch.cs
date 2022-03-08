namespace dk.itu.game.msc.cgdl.LanguageParser
{
    public interface ITokenMatch
    {
        string RemainingText { get; set; }
        IToken Token { get; set; }
        string Value { get; set; }
    }
}