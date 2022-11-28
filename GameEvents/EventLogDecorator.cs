using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Threading.Tasks;

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

        public async Task Dispatch(IEvent @event)
        {
            logger.AppendLog(@event);
            await decoratee.Dispatch(@event);
        }
    }
}
