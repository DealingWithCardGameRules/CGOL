using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.Distribution
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task Handle(TCommand command, IEventDispatcher eventDispatcher);
    }
}
