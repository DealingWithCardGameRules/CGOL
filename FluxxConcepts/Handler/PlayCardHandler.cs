using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using System;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Handler
{
    public class PlayCardHandler : ICommandHandler<PlayCard>
    {
        private readonly ITimeProvider timeProvider;
        private readonly IDispatcher dispatcher;

        public PlayCardHandler(ITimeProvider timeProvider, IDispatcher dispatcher)
        {
            this.timeProvider = timeProvider ?? throw new ArgumentNullException(nameof(timeProvider));
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public void Handle(PlayCard command, IEventDispatcher eventDispatcher)
        {
            if (command.Card == null)
                throw new Exception("No card selected");

            var card = dispatcher.Dispatch(new GetCard(command.Source, command.Card.Value));

            if (card == null)
                throw new Exception($"Card not found: {command.Card}");

            var revealEvent = new CardRevealed(timeProvider.Now, command.ProcessId, command.Source, card);
            eventDispatcher.Dispatch(revealEvent);

            var template = dispatcher.Dispatch(new GetTemplate(card.Template));
            if (template == null)
                return; // No instantanious effects to resolve

            foreach (var effect in template.Instantaneous)
                dispatcher.Dispatch(effect);
        }
    }
}
