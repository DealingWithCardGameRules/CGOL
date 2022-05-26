using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Linq;

namespace dk.itu.game.msc.cgol.CommonConcepts.Handlers
{
    public class PlaceWithHandler : ICommandHandler<PlaceWith>
    {
        private readonly ITimeProvider timeProvider;
        private readonly IDispatcher dispatcher;

        public PlaceWithHandler(ITimeProvider timeProvider, IDispatcher dispatcher)
        {
            this.timeProvider = timeProvider ?? throw new ArgumentNullException(nameof(timeProvider));
            this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        }

        public void Handle(PlaceWith command, IEventDispatcher eventDispatcher)
        {
            if (command.CardId == null)
                throw new Exception("No card specified. Make sure the effect is place as permanent or instantanious.");

            var player = dispatcher.Dispatch(new CurrentPlayer());
            if (player == null)
                throw new Exception("No current player found. Please set players.");

            var getCollectionName = new GetCollectionNames
            {
                WithTags = command.Tags,
                OwnedBy = player.Index
            };
            var collection = dispatcher.Dispatch(getCollectionName).SingleOrDefault();
            if (collection == null)
                throw new Exception("No collection found. Remember to add tags to collection and assign ownership to players.");

            var source = dispatcher.Dispatch(new GetCollectionContainingCard(command.CardId.Value));

            if (source == null)
                throw new Exception("Unable to locate card in any collection.");

            var @event = new CardMoved(timeProvider.Now, command.Instance, source, collection, command.CardId.Value);
            eventDispatcher.Dispatch(@event);
        }
    }
}
