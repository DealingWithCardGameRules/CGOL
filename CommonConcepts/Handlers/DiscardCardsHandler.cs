using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
{
    public class DiscardCardsHandler : ICommandHandler<DiscardCards>
    {
        private readonly ITimeProvider timeProvider;
        private readonly IDispatcher dispatcher;

        public DiscardCardsHandler(ITimeProvider timeProvider, IDispatcher dispatcher)
        {
            this.timeProvider = timeProvider ?? throw new ArgumentNullException(nameof(timeProvider));
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public void Handle(DiscardCards command, IEventDispatcher eventDispatcher)
        {
            if (!dispatcher.Dispatch(new HasCollection(command.Source)))
                throw new Exception($"The source collection \"{command.Source}\" was not found. Remember to declare the collection using {nameof(CreateDeck)}, {nameof(CreateZone)} or {nameof(CreateHand)}");

            if (!dispatcher.Dispatch(new HasCollection(command.Destination)))
                throw new Exception($"The destination collection \"{command.Destination}\" was not found. Remember to declare the collection using {nameof(CreateDeck)}, {nameof(CreateZone)} or {nameof(CreateHand)}");

            var cards = dispatcher.Dispatch(new GetCards(command.Source, command.Tags));
            
            foreach (var card in cards)
                eventDispatcher.Dispatch(new CardMoved(timeProvider.Now, command.ProcessId, command.Source, command.Destination, card.Instance));
        }
    }
}
