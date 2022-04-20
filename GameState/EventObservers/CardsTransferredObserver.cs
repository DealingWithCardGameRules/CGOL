using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using System.Linq;

namespace dk.itu.game.msc.cgdl.GameState.EventObservers
{
    public class CardsTransferredObserver : IEventObserver<CardsTransferred>
    {
        private readonly Game game;

        public CardsTransferredObserver(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public void Invoke(CardsTransferred @event)
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
