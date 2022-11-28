using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.FluxxConcepts.Commands;
using dk.itu.game.msc.cgol.FluxxConcepts.Events;
using dk.itu.game.msc.cgol.FluxxConcepts.Queries;
using System;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Handler
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

        public async Task Handle(PlayLimit command, IEventDispatcher eventDispatcher)
        {
            var currentPlayLimit = await dispatcher.Dispatch(new GetPlayLimit());
            if (command.Limit < 1)
                throw new ArgumentException("In Fluxx the draw limit must be a positive number.", nameof(command.Limit));

            if (currentPlayLimit != command.Limit)
                await eventDispatcher.Dispatch(new PlayLimitSet(timeProvider.Now, command.ProcessId, command.Limit));
        }
    }
}
