using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.CommonConcepts.Handlers
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

        public async Task Handle(PlaceIn command, IEventDispatcher eventDispatcher)
        {
            if (command.CardId == null)
                throw new Exception("No card specified. Make sure the effect is place as permanent or instantanious.");

            var source = await dispatcher.Dispatch(new GetCollectionContainingCard(command.CardId.Value));

            if (source == null)
                throw new Exception("Unable to locate card in any collection.");

            var @event = new CardMoved(timeProvider.Now, command.Instance, source, command.Collection, command.CardId.Value);
            await eventDispatcher.Dispatch(@event);
        }
    }
}
