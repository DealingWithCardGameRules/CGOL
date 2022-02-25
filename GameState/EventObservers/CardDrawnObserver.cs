using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using System;

namespace dk.itu.game.msc.cgdl.GameState.EventObservers
{
    public class CardDrawnObserver : IEventObserver<CardDrawn>
    {
        private readonly Game game;

        public CardDrawnObserver(Game game)
        {
            this.game = game ?? throw new ArgumentNullException(nameof(game));
        }

        public void Invoke(CardDrawn @event)
        {
            var card = game.GetCard(@event.Source) ?? throw new NullReferenceException($"Fatal event exception, no cards in source: {@event.Source}");
            game.AddCard(@event.Distination, card);
            game.RemoveCard(@event.Source, card.Instance);
        }
    }
}
