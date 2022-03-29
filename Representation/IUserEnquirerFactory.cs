namespace dk.itu.game.msc.cgdl.Representation
{
    public interface IUserEnquirerFactory
    {
        IUserEnquirer Create(PlayerRepository playerRepository);
    }
}
