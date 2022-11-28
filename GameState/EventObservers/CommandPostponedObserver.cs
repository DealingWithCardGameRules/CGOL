using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.GameState.EventObservers
{
    public class CommandPostponedObserver : IEventObserver<CommandPostponed>
    {
        private readonly CommandRepository repository;

        internal CommandPostponedObserver(CommandRepository repository)
        {
            this.repository = repository ?? throw new System.ArgumentNullException(nameof(repository));
        }

        public async Task Invoke(CommandPostponed @event)
        {
            var label = @event.Label ?? @event.Command.GetType().Name;
            repository.AddCommand(label, @event.Command);
        }
    }
}
