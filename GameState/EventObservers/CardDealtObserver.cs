using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using System;

namespace dk.itu.game.msc.cgdl.GameState.EventObservers
{
    public class CardDealtObserver : IEventObserver<CardDealt>
    {
        private readonly Game game;

        public CardDealtObserver(Game game)
        {
            this.game = game ?? throw new ArgumentNullException(nameof(game));
        }

        public void Invoke(CardDealt @event)
        {
            var card = game.GetCard(@event.Source) ?? throw new NullReferenceException($"Fatal event exception, no cards in source: {@event.Source}");
            game.AddCard(@event.Distination, card);
            game.RemoveCard(@event.Source, card.Instance);
        }
    }
}
