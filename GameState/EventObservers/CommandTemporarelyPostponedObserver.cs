using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.Distribution;

namespace dk.itu.game.msc.cgdl.GameState.EventObservers
{
    public class CommandTemporarelyPostponedObserver : IEventObserver<CommandTemporarelyPostponed>
    {
        private readonly CommandRepository repository;

        public CommandTemporarelyPostponedObserver(CommandRepository repository)
        {
            this.repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
        }

        public void Invoke(CommandTemporarelyPostponed @event)
        {
            var label = @event.Label ?? @event.Command.GetType().Name;
            repository.AddCommand(label, @event.Command);
        }
    }
}
