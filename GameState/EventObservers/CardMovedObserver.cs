using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.GameState.EventObservers
{
    public class CardMovedObserver : IEventObserver<CardMoved>
    {
        private readonly Game game;

        internal CardMovedObserver(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public async Task Invoke(CardMoved @event)
        {
            var card = game.GetCard(@event.Source, @event.CardId);
            if (card == null)
                return;

            game.RemoveCard(@event.Source, @event.CardId);
            game.AddCard(@event.Destination, card);
        }
    }
}
