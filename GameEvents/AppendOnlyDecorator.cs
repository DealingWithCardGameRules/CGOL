using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Collections.Generic;

namespace dk.itu.game.msc.cgol.GameEvents
{
    internal class AppendOnlyDecorator : IEventLogger
    {
        private readonly IEventLogger decoratee;
        private DateTime lastEventTime;

        public AppendOnlyDecorator(IEventLogger decoratee)
        {
            this.decoratee = decoratee ?? throw new ArgumentNullException(nameof(decoratee));
        }

        public IEnumerable<IEvent> EventLog => decoratee.EventLog;

        public void AppendLog(IEvent @event)
        {
            if (@event.EventTime < lastEventTime)
                throw new Exception($"Event ({@event.GetType().FullName}) out of order. Event time was: {@event.EventTime}, expected newer than: {lastEventTime}. Proccess: {@event.ProcessId}");

            decoratee.AppendLog(@event);

            lastEventTime = @event.EventTime;
        }
    }
}
