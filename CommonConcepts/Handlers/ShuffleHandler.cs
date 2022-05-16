using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;
using dk.itu.game.msc.cgdl.CommonConcepts.Queries;
using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
{
    public class ShuffleHandler : ICommandHandler<Shuffle>
    {
        private readonly ITimeProvider timeProvider;
        private readonly IDispatcher dispatcher;

        public ShuffleHandler(ITimeProvider timeProvider, IDispatcher dispatcher)
        {
            this.timeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
            this.dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        }

        public void Handle(Shuffle command, IEventDispatcher eventDispatcher)
        {
            if (!dispatcher.Dispatch(new HasCollection(command.Collection)))
                throw new Exception($"The collection \"{command.Collection}\" was not found. Remember to declare the collection using {nameof(CreateDeck)}, {nameof(CreateZone)} or {nameof(CreateHand)}");

            var random = new Random();
            var @event = new CollectionShuffled(timeProvider.Now, command.ProcessId, command.Collection, random.Next());
            eventDispatcher.Dispatch(@event);
        }
    }
}
