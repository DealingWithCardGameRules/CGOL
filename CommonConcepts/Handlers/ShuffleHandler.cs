﻿using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.CommonConcepts.Queries;
using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.CommonConcepts.Handlers
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

        public async Task Handle(Shuffle command, IEventDispatcher eventDispatcher)
        {
            if (!await dispatcher.Dispatch(new HasCollection(command.Collection)))
                throw new Exception($"The collection \"{command.Collection}\" was not found. Remember to declare the collection using {nameof(CreateDeck)}, {nameof(CreateZone)} or {nameof(CreateHand)}");

            var random = new Random();
            var @event = new CollectionShuffled(timeProvider.Now, command.ProcessId, command.Collection, random.Next());
            await eventDispatcher.Dispatch(@event);
        }
    }
}
