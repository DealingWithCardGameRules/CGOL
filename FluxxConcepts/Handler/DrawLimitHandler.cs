using dk.itu.game.msc.cgdl.CommandCentral;
using dk.itu.game.msc.cgdl.FluxxConcepts.Commands;
using dk.itu.game.msc.cgdl.FluxxConcepts.Events;
using dk.itu.game.msc.cgdl.FluxxConcepts.Queries;
using System;

namespace dk.itu.game.msc.cgdl.FluxxConcepts.Handler
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

        public void Handle(DrawLimit command, IEventDispatcher eventDispatcher)
        {
            var currentDrawLimit = dispatcher.Dispatch(new GetDrawLimit());
            if (command.Limit < 1)
                throw new ArgumentException("In Fluxx the draw limit must be a positive number.", nameof(command.Limit));

            if (currentDrawLimit != command.Limit)
                eventDispatcher.Dispatch(new DrawLimitSet(timeProvider.Now, command.ProcessId, command.Limit));
        }
    }
}
