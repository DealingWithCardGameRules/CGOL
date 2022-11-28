using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace Agents
{
    public interface ICGOLAgent
    {
        Task<ICommand> Choose(IEvent[] state);
    }
}
