namespace dk.itu.game.msc.cgdl.LanguageParser.Tokens
{
    public interface ITokenMatch
    {
        //string RemainingText { get; set; }
        int CharacterLength { get; set; }
        IToken Token { get; set; }
    }
}