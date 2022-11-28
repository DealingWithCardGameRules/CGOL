using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.GameState.EventObservers
{
    public class CardDrawnObserver : IEventObserver<CardDrawn>
    {
        private readonly Game game;
        private readonly IDispatcher dispatcher;

        internal CardDrawnObserver(Game game, IDispatcher dispatcher)
        {
            this.game = game ?? throw new ArgumentNullException(nameof(game));
            this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        }

        public async Task Invoke(CardDrawn @event)
        {
            var card = game.GetCard(@event.Source) ?? throw new NullReferenceException($"Fatal event exception, no cards in source: {@event.Source}");
            game.AddCard(@event.Destination, card);
            game.RemoveCard(@event.Source, card.Instance);

            var template = await dispatcher.Dispatch(new GetTemplate(card.Template));
            if (template == null || !template.Acquisition.Any())
                return; // No instantanious effects to resolve

            await dispatcher.Dispatch(new ResolveAcquisitionEffects(card));
        }
    }
}
