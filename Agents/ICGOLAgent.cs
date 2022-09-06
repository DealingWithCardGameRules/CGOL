using dk.itu.game.msc.cgol.Distribution;

namespace Agents
{
    public interface ICGOLAgent
    {
        ICommand Choose(IEvent[] state);
    }
}
