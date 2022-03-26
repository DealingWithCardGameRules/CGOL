using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;

namespace dk.itu.game.msc.cgdl.GameState.EventObservers
{
    public class CommandPostponedObserver : IEventObserver<CommandPostponed>
    {
        private readonly CommandRepository repository;

        public CommandPostponedObserver(CommandRepository repository)
        {
            this.repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
        }

        public void Invoke(CommandPostponed @event)
        {
            var label = @event.Label ?? @event.Command.GetType().Name;
            repository.AddCommand(label, @event.Command);
        }
    }
}
