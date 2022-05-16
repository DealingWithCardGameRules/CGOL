using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
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

        public void Handle(PassTurn command, IEventDispatcher eventDispatcher)
        {
            var player = dispatcher.Dispatch(new CurrentPlayer());
            eventDispatcher.Dispatch(new TurnEnded(timeProvider.Now, command.ProcessId));
            var maxPlayers = dispatcher.Dispatch(new GetNumberOfPlayers());
            if (player != null)
            {
                var newPlayer = (player.Index % maxPlayers) + 1;
                if (newPlayer != player.Index)
                    eventDispatcher.Dispatch(new CurrentPlayerSelected(timeProvider.Now, command.ProcessId, newPlayer));
            }
            dispatcher.Dispatch(new Start());
        }
    }
}
