using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.Distribution;
using System.Linq;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.GameState.EventObservers
{
    public class CardsTransferredObserver : IEventObserver<CardsTransferred>
    {
        private readonly Game game;

        internal CardsTransferredObserver(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public async Task Invoke(CardsTransferred @event)
        {
            var cards = game.GetCards(@event.Source).ToArray();
            for(int i = 0; i < cards.Length; i++)
            {
                game.AddCard(@event.Destination, cards[i]);
                game.RemoveCard(@event.Source, cards[i].Instance);
            }
        }
    }
}
