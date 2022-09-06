using dk.itu.game.msc.cgol.Distribution;
using System;

namespace dk.itu.game.msc.cgol.GameEvents
{
    public class EventLogDecorator : IEventDispatcher
    {
        private readonly IEventDispatcher decoratee;
        private readonly IEventLogger logger;

        public EventLogDecorator(IEventDispatcher decoratee, IEventLogger logger)
        {
            this.decoratee = decoratee ?? throw new ArgumentNullException(nameof(decoratee));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void Dispatch(IEvent @event)
        {
            logger.AppendLog(@event);
            decoratee.Dispatch(@event);
        }
    }
}
