using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
{
    public class SimplyPlaceInCollection : ICommandHandler<PlaceIn>
    {
        private readonly ITimeProvider timeProvider;
        private readonly IDispatcher dispatcher;

        public SimplyPlaceInCollection(ITimeProvider timeProvider, IDispatcher dispatcher)
        {
            this.timeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public void Handle(PlaceIn command, IEventDispatcher eventDispatcher)
        {
            if (command.CardId == null)
                throw new Exception("No card specified. Make sure the effect is place as permanent or instantanious.");

            var source = dispatcher.Dispatch(new GetCollectionContainingCard(command.CardId.Value));

            if (source == null)
                throw new Exception("Unable to locate card in any collection.");

            var @event = new CardMoved(timeProvider.Now, command.Instance, source, command.Collection, command.CardId.Value);
            eventDispatcher.Dispatch(@event);
        }
    }
}
