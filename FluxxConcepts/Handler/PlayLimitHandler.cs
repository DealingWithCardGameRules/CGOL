using dk.itu.game.msc.cgdl.Distribution;
using dk.itu.game.msc.cgdl.FluxxConcepts.Commands;
using dk.itu.game.msc.cgdl.FluxxConcepts.Events;
using dk.itu.game.msc.cgdl.FluxxConcepts.Queries;
using System;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Handler
{
    public class PlayLimitHandler : ICommandHandler<PlayLimit>
    {
        private readonly ITimeProvider timeProvider;
        private readonly IDispatcher dispatcher;

        public PlayLimitHandler(ITimeProvider timeProvider, IDispatcher dispatcher)
        {
            this.timeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public void Handle(PlayLimit command, IEventDispatcher eventDispatcher)
        {
            var currentPlayLimit = dispatcher.Dispatch(new GetPlayLimit());
            if (command.Limit < 1)
                throw new ArgumentException("In Fluxx the draw limit must be a positive number.", nameof(command.Limit));

            if (currentPlayLimit != command.Limit)
                eventDispatcher.Dispatch(new PlayLimitSet(timeProvider.Now, command.ProcessId, command.Limit));
        }
    }
}
