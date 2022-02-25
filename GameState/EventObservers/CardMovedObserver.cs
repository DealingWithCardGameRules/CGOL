using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;

namespace dk.itu.game.msc.cgdl.GameState.EventObservers
{
    public class CardMovedObserver : IEventObserver<CardMoved>
    {
        private readonly Game game;

        public CardMovedObserver(Game game)
        {
            this.game = game ?? throw new System.ArgumentNullException(nameof(game));
        }

        public void Invoke(CardMoved @event)
        {
            var card = game.GetCard(@event.SourceId, @event.CardId);
            if (card == null)
                return;

            game.RemoveCard(@event.SourceId, @event.CardId);
            game.AddCard(@event.DestinationId, card);
        }
    }
}
