using dk.itu.game.msc.cgdl.Distribution;
using System;

namespace dk.itu.game.msc.cgdl.GameEvents
{
    public class EventLogDecorator : IEventDispatcher
    {
        public bool EnableLogging { get; set; }
        private readonly IEventDispatcher decoratee;
        private readonly IEventLogger logger;

        public EventLogDecorator(IEventDispatcher decoratee, IEventLogger logger)
        {
            this.decoratee = decoratee ?? throw new ArgumentNullException(nameof(decoratee));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            EnableLogging = true;
        }

        public void Dispatch(IEvent @event)
        {
            if (EnableLogging)
                logger.AppendLog(@event);

            decoratee.Dispatch(@event);
        }
    }
}
