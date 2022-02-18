using dk.itu.game.msc.cgdl.CommandCentral;
using Newtonsoft.Json;
using System;
using System.IO;

namespace dk.itu.game.msc.cgdl.GameEvents
{
    internal class EventLogger : IEventLogger
    {
        private readonly string eventStore;
        private DateTime lastEventTime;

        public EventLogger(string eventStore)
        {
            this.eventStore = eventStore ?? throw new ArgumentNullException(nameof(eventStore));
        }

        public void AppendLog(IEvent @event)
        {
            if (@event.EventTime <= lastEventTime)
            {
                Console.Write($"Waring! Ignored event with event time: {@event.EventTime}, newest event time is: {lastEventTime}.");
                return;
            }

            var jsonEvent = JsonConvert.SerializeObject(@event);
            var output = $"\"{@event.GetType().Name}\":{jsonEvent}";
            using (var eventStoreWriter = new StreamWriter(eventStore, append: true))
                eventStoreWriter.WriteLine(output);

            lastEventTime = @event.EventTime;
        }
    }
}
