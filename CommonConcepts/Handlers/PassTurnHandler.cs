using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.CommonConcepts.Handlers
{
    public class PassTurnHandler : ICommandHandler<PassTurn>
    {
        private readonly ITimeProvider timeProvider;
        private readonly IDispatcher dispatcher;

        public PassTurnHandler(ITimeProvider timeProvider, IDispatcher dispatcher)
        {
            this.timeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public async Task Handle(PassTurn command, IEventDispatcher eventDispatcher)
        {
            var player = await dispatcher.Dispatch(new CurrentPlayer());
            await eventDispatcher.Dispatch(new TurnEnded(timeProvider.Now, command.ProcessId));
            var maxPlayers = await dispatcher.Dispatch(new GetNumberOfPlayers());
            if (player != null)
            {
                var newPlayer = (player.Index % maxPlayers) + 1;
                if (newPlayer != player.Index)
                    await eventDispatcher.Dispatch(new CurrentPlayerSelected(timeProvider.Now, command.ProcessId, newPlayer));
            }
            await dispatcher.Dispatch(new Start());
        }
    }
}
