﻿using dk.itu.game.msc.cgol.Distribution;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dk.itu.game.msc.cgol.GameEvents
{
    public class EventRecorder : IEventRecorder
    {
        private readonly IEventDispatcher eventDispatcher;
        private readonly IEventLogger eventLogger;
        private bool recording = true;

        public EventRecorder(IEventDispatcher eventDispatcher, IEventLogger eventLogger)
        {
            var dispatcher = eventDispatcher ?? throw new ArgumentNullException(nameof(eventDispatcher));
            this.eventLogger = eventLogger ?? throw new ArgumentNullException(nameof(eventLogger));
            this.eventDispatcher = new EventLogDecorator(dispatcher, this.eventLogger);
        }

        public IEnumerable<IEvent> RecordedEvents => eventLogger.EventLog;

        public async Task Replay(IEnumerable<IEvent> events)
        {
            recording = false;
            foreach (var @event in events)
            {
                try
                {
                    await eventDispatcher.Dispatch(@event);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception thrown: {ex.Message}");
                }
            }
                
            recording = true;
        }

        public async Task Dispatch(IEvent @event)
        {
            if (recording)
                await eventDispatcher.Dispatch(@event);
        }
    }
}
