using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.CommonConcepts.Handlers
{
    public class SimplyDeclarePlayers : ICommandHandler<SetPlayers>
    {
        private readonly ITimeProvider timeProvider;

        public SimplyDeclarePlayers(ITimeProvider timeProvider)
        {
            this.timeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
        }

        public async Task Handle(SetPlayers command, IEventDispatcher eventDispatcher)
        {
            for(int i = 0; i < command.Amount; i++)
            {
                var player = new SimplePlayer
                {
                    Index = i + 1,
                    Name = $"player_{i + 1}",
                    Identity = $"player_{i + 1}"
                };
                await eventDispatcher.Dispatch(new PlayerDeclared(timeProvider.Now, command.ProcessId, player));
            }
            await eventDispatcher.Dispatch(new CurrentPlayerSelected(timeProvider.Now, command.ProcessId, 1));
        }
    }
}
