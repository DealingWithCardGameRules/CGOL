﻿using dk.itu.game.msc.cgol.CommonConcepts.Commands;
using dk.itu.game.msc.cgol.CommonConcepts.Events;
using dk.itu.game.msc.cgol.Distribution;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.CommonConcepts.Handlers
{
    public class ShuffleIntoHandler : ICommandHandler<ShuffleInto>
    {
        private readonly ITimeProvider timeProvider;
        private readonly IDispatcher dispatcher;

        public ShuffleIntoHandler(ITimeProvider timeProvider, IDispatcher dispatcher)
        {
            this.timeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public async Task Handle(ShuffleInto command, IEventDispatcher eventDispatcher)
        {
            await eventDispatcher.Dispatch(new CardsTransferred(timeProvider.Now, command.ProcessId, command.From, command.To));
            await dispatcher.Dispatch(new Shuffle(command.To));
        }
    }
}
