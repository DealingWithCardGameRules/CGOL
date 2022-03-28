using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
{
    public class SimplyDeclarePlayers : ICommandHandler<SetPlayers>
    {
        private readonly ITimeProvider timeProvider;

        public SimplyDeclarePlayers(ITimeProvider timeProvider)
        {
            this.timeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
        }

        public void Handle(SetPlayers command, IEventDispatcher eventDispatcher)
        {
            for(int i = 0; i < command.Amount; i++)
            {
                var player = new SimplePlayer
                {
                    Index = i + 1,
                    Name = $"player_{i + 1}",
                    Identity = $"player_{i + 1}"
                };
                eventDispatcher.Dispatch(new PlayerDeclared(timeProvider.Now, command.ProcessId, player));
            }
            eventDispatcher.Dispatch(new CurrentPlayerSelected(timeProvider.Now, command.ProcessId, 1));
        }
    }
}
