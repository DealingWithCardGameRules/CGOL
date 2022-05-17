namespace dk.itu.game.msc.cgdl.Parser.Tokens
{
    public interface ITokenMatch
    {
        //string RemainingText { get; set; }
        int Length { get; set; }
        Token Token { get; set; }
    }
}