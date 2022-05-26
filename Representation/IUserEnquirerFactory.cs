namespace dk.itu.game.msc.cgol.Representation
{
    public interface IUserEnquirerFactory
    {
        IUserEnquirer Create(PlayerRepository playerRepository);
    }
}
