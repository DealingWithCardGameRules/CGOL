﻿using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.CommonConcepts.Commands;
using dk.itu.game.msc.cgdl.CommonConcepts.Events;

namespace dk.itu.game.msc.cgdl.CommonConcepts.Handlers
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

        public void Handle(ShuffleInto command, IEventDispatcher eventDispatcher)
        {
            eventDispatcher.Dispatch(new CardsTransferred(timeProvider.Now, command.ProcessId, command.From, command.To));
            dispatcher.Dispatch(new Shuffle(command.To));
        }
    }
}
