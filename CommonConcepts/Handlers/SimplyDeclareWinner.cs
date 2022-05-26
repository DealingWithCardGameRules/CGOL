using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;

namespace dk.itu.game.msc.cgol.CommonConcepts.Handlers
{
    public class SimplyDeclareWinner : ICommandHandler<Win>
    {
        private readonly ITimeProvider timeProvider;
        private readonly IQueryDispatcher dispatcher;

        public SimplyDeclareWinner(ITimeProvider timeProvider, IQueryDispatcher dispatcher)
        {
            this.timeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public void Handle(Win command, IEventDispatcher eventDispatcher)
        {
            var playerIndex = command.PlayerIndex ?? dispatcher.Dispatch(new CurrentPlayer())?.Index;
            eventDispatcher.Dispatch(new PlayerWon(timeProvider.Now, command.ProcessId, playerIndex));
        }
    }
}
