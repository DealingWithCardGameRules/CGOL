using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.GameState.EventObservers
{
    public class HandDeclaredObserver : IEventObserver<HandDeclared>
    {
        private readonly Game game;

        internal HandDeclaredObserver(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public async Task Invoke(HandDeclared @event)
        {
            game.AddCollection(new Hand(@event.Name));
        }
    }
}
