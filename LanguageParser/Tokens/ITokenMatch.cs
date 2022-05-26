namespace dk.itu.game.msc.cgol.Parser.Tokens
{
    public interface ITokenMatch
    {
        //string RemainingText { get; set; }
        int Length { get; set; }
        Token Token { get; set; }
    }
}