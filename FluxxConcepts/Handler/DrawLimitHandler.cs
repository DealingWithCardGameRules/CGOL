using dk.itu.game.msc.cgol.Distribution;
using dk.itu.game.msc.cgol.FluxxConcepts.Commands;
using dk.itu.game.msc.cgol.FluxxConcepts.Events;
using dk.itu.game.msc.cgol.FluxxConcepts.Queries;
using System;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.FluxxConcepts.Handler
{
    public class DrawLimitHandler : ICommandHandler<DrawLimit>
    {
        private readonly IDispatcher dispatcher;
        private readonly ITimeProvider timeProvider;

        public DrawLimitHandler(ITimeProvider timeProvider, IDispatcher dispatcher)
        {
            this.timeProvider = timeProvider ?? throw new System.ArgumentNullException(nameof(timeProvider));
            this.dispatcher = dispatcher ?? throw new System.ArgumentNullException(nameof(dispatcher));
        }

        public async Task Handle(DrawLimit command, IEventDispatcher eventDispatcher)
        {
            var currentDrawLimit = await dispatcher.Dispatch(new GetDrawLimit());
            if (command.Limit < 1)
                throw new ArgumentException("In Fluxx the draw limit must be a positive number.", nameof(command.Limit));

            if (currentDrawLimit != command.Limit)
                await eventDispatcher.Dispatch(new DrawLimitSet(timeProvider.Now, command.ProcessId, command.Limit));
        }
    }
}
